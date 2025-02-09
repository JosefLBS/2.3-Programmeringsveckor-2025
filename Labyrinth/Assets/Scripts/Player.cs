using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool isRotating = false;
    private float targetAngle = 0f;
    private float currentAngle = 0f;

    public bool Freeze = false; //Freezes Inputs

    bool TurnRight = false;
    bool TurnLeft = false;

    public bool Moving = false;

    float rotationSpeed = 5;
    float movementSpeed = 5;

    public float Stamina = 100;

    public bool Sprinting = false;
    bool StopSprinting = false;
    float SprintCD = 0;
    bool Sprint_Recovery = false;

    Vector3 TargetPosition;

    public bool rCrystal = false;

    bool rPowerReady = true;
    bool rPowerUsing = false;
    float rPowerTime = 5;
    float rDuration = 5;
    float r_CD = 0;

    public bool bCrystal = false;

    bool bPowerReady = true;
    float bPowerTime = 6;
    float bDuration = 6;
    float b_CD = 0;

    public bool Purple = false;

    public bool Key = false;

    [SerializeField]
    Animator animator;

    public GameObject BlueBlock;

    public Transform blockSpawner;
    
    public GameObject BlueCrystal;

    public GameObject RedCrystal;

    public Light PurpleLight;

    public Light RedLight;

    public Light BlueLight;

    Vector3 blockPosition;

    public Image StaminaBar;

    public float Staminaalbin, MaxStamina;

    public float AttackCost;
    public float RunCost;

    public Transform Spawn;

    [SerializeField]
    GameObject textGameObject1;

    TextMeshProUGUI textComponent1;

    [SerializeField]
    GameObject textGameObject2;

    TextMeshProUGUI textComponent2;

    Enemy1_Script enemy1;

    public GameObject ENEMY1;

    Items items;

    public GameObject ItemManager;

    public Material WallMaterial;

    public GameObject MovingWall;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        enemy1 = ENEMY1.GetComponent<Enemy1_Script>();

        items = ItemManager.GetComponent<Items>();

        textComponent1 = textGameObject1.GetComponent<TextMeshProUGUI>();
        textComponent2 = textGameObject2.GetComponent<TextMeshProUGUI>();

        textComponent1.enabled = false;
        textComponent2.enabled = false;
    }

    void Update()
    {      
        textComponent1.text = ("Blue Power Time Remaining: " + bPowerTime);
        textComponent2.text = ("Red Power Time Remaining: " + rPowerTime);

        StaminaBar.fillAmount = Stamina / MaxStamina;

        //Red Light intensity check
        if (enemy1.Hunting == true)
        {
            RedLight.intensity = 1;

            BlueLight.intensity = 1;
        }

        else
        {
            RedLight.intensity = 5.5f;

            BlueLight.intensity = 5.5f;
        }

        // Crystal Powers

        if (rCrystal && bCrystal)
        {
            MovingWall.SetActive(false);
        }

        if (Purple == true)
        {
            MovingWall.SetActive(true);
        }

        // RED CRYSTAL

        if (rCrystal == true)
        {
            animator.SetBool("RedCristal", true);

            if (rPowerReady == true && Purple == false)
            {
                animator.SetBool("Redpower", true);

                if (Input.GetKey(KeyCode.X))
                {
                    rPowerUsing = true;

                    rPowerReady = false;

                    animator.SetBool("Redpower", false);

                    r_CD = 0;

                    rDuration = 5;
                }
            }

            if (rPowerUsing)
            {
                textComponent2.enabled = true;

                RedLight.enabled = true;

                rDuration -= (Time.deltaTime);
                rPowerTime = Mathf.RoundToInt(rDuration);

                if (rPowerTime < 0)
                {
                    textComponent2.enabled = false;

                    rPowerUsing = false;

                    RedLight.enabled = false;
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
        }

        // Blue Crystal

        if (bCrystal == true)
        {
            animator.SetBool("BlueCrystal", true);

            if (bPowerReady == false)
            {
                b_CD += Time.deltaTime;

                bDuration -= Time.deltaTime;
                bPowerTime = Mathf.RoundToInt(bDuration);

                BlueBlock.transform.position = blockPosition;

                if (bPowerTime < 0)
                {
                    BlueBlock.transform.position = blockSpawner.position;

                    BlueBlock.SetActive(false);

                    BlueLight.enabled = false;

                    textComponent1.enabled = false;
                }

                if (b_CD > 30)
                {
                    bPowerReady = true;
                }
            }

            if (bPowerReady == true)
            {
                animator.SetBool("BluePower", true);
            }
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


            RaycastHit hit;
            if (Physics.Raycast(transform.position, (transform.forward), out hit, Mathf.Infinity))
            {
                if (Physics.Raycast(transform.position, transform.forward, 5) == false || hit.collider.CompareTag("Item") == true || hit.collider.CompareTag("Radio") || hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("CheckPoint")  || hit.collider.CompareTag("Structure"))
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                    {
                        Freeze = true;

                        Moving = true;

                        TargetPosition = gameObject.transform.position + Vector3Int.RoundToInt(transform.forward) * 5;
                    }

                    if (bPowerReady && Purple == false && bCrystal)
                    {
                        // BluePower

                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            bDuration = 6;

                            animator.SetBool("BluePower", false);

                            bPowerReady = false;

                            BlueLight.enabled = true;

                            BlueBlock.SetActive(true);

                            blockPosition = BlueBlock.transform.position;

                            textComponent1.enabled = true;

                            b_CD = 0;
                        }
                    }
                }

                if (rPowerUsing)
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

        // Crystal Collecting
        
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
            if (items.RadioUsing == false)
            {
                gameObject.transform.position = Spawn.position;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall" && rPowerUsing == false)
        {
            transform.position = Spawn.position;

            TargetPosition = Spawn.position;

            Freeze = false;

        }
    }
}
