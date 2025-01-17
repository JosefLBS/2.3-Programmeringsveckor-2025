using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isRotating = false;
    private float targetAngle = 0f;
    private float currentAngle = 0f;

    private bool Freeze = false; //Freezes Inputs

    bool TurnRight = false;
    bool TurnLeft = false;

    public bool Moving = false;

    float rotationSpeed = 5;
    float movementSpeed = 5;

    float Stamina = 100;

    public bool Sprinting = false;
    bool StopSprinting = false;
    float SprintCD = 0;
    bool Sprint_Recovery = false;

    Vector3 TargetPosition;

    bool rCrystal = false;

    bool rPowerReady = true;
    bool rPowerUsing = false;
    float rPowerTime = 0;
    float r_CD = 0;

    bool bCrystal = false;

    bool bPowerReady = true;
    float bPowerTime = 0;
    float b_CD = 0;

    bool Purple = false;

    public bool Key = false;

    [SerializeField]
    Animator animator;

    public GameObject BlueBlock;

    public Transform blockSpawner;
    
    public GameObject BlueCrystal;

    public GameObject RedCrystal;

    public Light PurpleLight;

    Vector3 blockPosition;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Crystal Powers

        if (rCrystal == true)
        {
            animator.SetBool("RedCristal", true);
        }

        if (bCrystal == true)
        {
            animator.SetBool("BlueCrystal", true);
        }

        // RED CRYSTAL
        
        if (rPowerReady == true)
        {
            animator.SetBool("Redpower", true);

            if (Input.GetKey(KeyCode.X))
            {
                rPowerUsing = true;

                rPowerReady = false;

                animator.SetBool("Redpower", false);

                r_CD = 0;

                rPowerTime = 0;
            }
        }

        if (rPowerUsing)
        {
            rPowerTime += Time.deltaTime;

            if (rPowerTime > 5)
            {
                rPowerUsing = false;
            }
        }

        if (rPowerReady == false && rCrystal && rPowerUsing == false)
        {
            r_CD += Time.deltaTime;

            if (r_CD > 30)
            {
                rPowerReady = true;
            }
        }

        // BLUE CRYSTAL


        if (bPowerReady == false)
        {
            b_CD += Time.deltaTime;

            bPowerTime += Time.deltaTime;

            BlueBlock.transform.position = blockPosition;

            if (bPowerTime > 20)
            {
                BlueBlock.transform.position = blockSpawner.position;
                
                BlueBlock.SetActive(false);
            }
            
            if (b_CD > 40)
            {
                bPowerReady = true;
            }
        }

        if (bPowerReady == true)
        {
            animator.SetBool("BluePower", true);
        }

        if (Purple == true)
        {
            animator.SetBool("PurplePower", true);

            PurpleLight.enabled = true;
        }

        if (StopSprinting == true)
        {
            SprintCD += Time.deltaTime;

            if (SprintCD >= 1)
            {
                StopSprinting = false;

                Sprint_Recovery = true;
            }
        }

        if (Sprint_Recovery == true)
        {
            if (Stamina <= 100)
            {
                Stamina += Time.deltaTime * 10;
            }

            if (Stamina > 100)
            {
                Stamina = 100;
            }
        }

        if (Sprinting == true)
        {
            Sprint_Recovery = false;
            
            if (Stamina >= 0)
            {
                if (Moving)
                {
                    Stamina -= Time.deltaTime * 20;
                }
            }

            if (Stamina < 0)
            {
                Stamina = 0;
            }
        }
        
        if (!Freeze)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Freeze = true;

                rotationSpeed = 5f;

                TurnRight = true;
                
                isRotating = true;
                targetAngle = currentAngle + 90f;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Freeze = true;

                rotationSpeed = 5f;

                TurnLeft = true;

                isRotating = true;
                targetAngle = currentAngle - 90f;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Freeze = true;

                rotationSpeed = 3f;

                TurnRight = true;

                isRotating = true;
                targetAngle = currentAngle + 180f;
            }

            if (Physics.Raycast(transform.position, transform.forward, 5) == false)
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    Freeze = true;

                    Moving = true;

                    TargetPosition = gameObject.transform.position + Vector3Int.RoundToInt(transform.forward) * 5;
                }

                if (bPowerReady)
                {
                    // BluePower

                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        bPowerTime = 0;

                        b_CD = 0;

                        animator.SetBool("BluePower", false);

                        bPowerReady = false;

                        BlueBlock.SetActive(true);

                        blockPosition = BlueBlock.transform.position;
                    }                          
                }
            }

            RaycastHit hit;
            if (rPowerUsing)
            {
                if (Physics.Raycast(transform.position, (transform.forward), out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("OuterWall") == false && Physics.Raycast(transform.position, transform.forward, 5) == true)
                    {
                        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                        {
                            Freeze = true;

                            Moving = true;

                            TargetPosition = gameObject.transform.position + Vector3Int.RoundToInt(transform.forward) * 5;
                        }
                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {   
            if (Stamina > 0)
            {
                StopSprinting = false;
                
                movementSpeed = 20f;

                rotationSpeed = 20f;

                Sprinting = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift) || Stamina <= 0)
        {
            if (StopSprinting == false)
            {
                StopSprinting = true;

                movementSpeed = 5f;

                rotationSpeed = 5f;

                Sprinting = false;

                SprintCD = 0f;
            }
        }

        if (Moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, TargetPosition) < 0.01f)
            {
                gameObject.transform.position = TargetPosition;
                
                Moving = false;

                Freeze = false;
            }
        }

        if (isRotating)
        {
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);

            if (TurnRight)
            {
                if (targetAngle - currentAngle < 1)
                {
                    currentAngle = targetAngle;
                }
            }

            if (TurnLeft) // -> Seperates Right- And Left Turns
            {
                if (targetAngle - currentAngle > -1)
                {
                    currentAngle = targetAngle;
                }
            }
            
            if (Mathf.Abs(currentAngle - targetAngle) < 0.1f)
            {
                isRotating = false;

                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                currentAngle = targetAngle; // Ensure precise final angle

                TurnRight = false;

                TurnLeft = false;
                
                Freeze = false; // Enables Player Inputs
            }
        }

        if (transform.position.x == BlueCrystal.transform.position.x && transform.position.z == BlueCrystal.transform.position.z)
        {
            bCrystal = true;

            BlueCrystal.SetActive(false);
        }

        if (transform.position.x == RedCrystal.transform.position.x && transform.position.z == RedCrystal.transform.position.z)
        {
            rCrystal = true;

            RedCrystal.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Gotcha");
        }
    }
}
