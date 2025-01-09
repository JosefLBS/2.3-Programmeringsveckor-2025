using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust for desired speed
    private bool isRotating = false;
    private float targetAngle = 0f;
    private float currentAngle = 0f;

    private bool Freeze = false;

    bool TurnRight = false;
    bool TurnLeft = false;

    void Update()
    {
        if (!Freeze)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Freeze = true;

                TurnRight = true;
                
                isRotating = true;
                targetAngle = currentAngle + 90f;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Freeze = true;

                TurnLeft = true;

                isRotating = true;
                targetAngle = currentAngle - 90f;
            }
        }

        if (isRotating)
        {
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 5f);
            transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);

            if (TurnRight)
            {
                if (targetAngle - currentAngle < 1)
                {
                    currentAngle = targetAngle;
                }
            }

            if (TurnLeft)
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
                
                Freeze = false;
            }
        }
    }
}
