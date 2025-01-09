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

    float rotationSpeed = 5;

    void Update()
    {
        if (!Freeze)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Freeze = true;

                rotationSpeed = 5f;

                TurnRight = true;
                
                isRotating = true;
                targetAngle = currentAngle + 90f;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Freeze = true;

                rotationSpeed = 5f;

                TurnLeft = true;

                isRotating = true;
                targetAngle = currentAngle - 90f;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Freeze = true;

                rotationSpeed = 3f;

                TurnRight = true;

                isRotating = true;
                targetAngle = currentAngle + 180f;
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
}
