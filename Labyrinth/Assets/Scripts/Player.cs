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

    bool Moving = false;

    float rotationSpeed = 5;
    float movementSpeed = 5;

    float Stamina = 100;

    bool Sprinting = false;
    bool StopSprinting = false;
    float SprintCD = 0;
    bool Sprint_Recovery = false;

    Vector3 TargetPosition;

    void Update()
    {
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

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Freeze = true;
                
                Moving = true;

                TargetPosition = gameObject.transform.position + Vector3Int.RoundToInt(transform.forward) * 5;
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
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == collision.gameObject.CompareTag("Enemy"))
        {
            print("Gotcha");
        }
    }
}
