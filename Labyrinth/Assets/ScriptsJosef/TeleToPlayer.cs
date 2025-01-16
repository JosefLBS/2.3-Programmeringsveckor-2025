using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeleToPlayer : MonoBehaviour
{
    public GameObject objectToTeleport;
    public Transform playerTransform;
    public Vector3 heldZone1 = new Vector3(5, 5, 5);
    public Vector3 heldZone2 = new Vector3(7, 7, 7);
    public Vector3 heldZone3 = new Vector3(9, 9, 9);
    public float time = 0f;
    public float timeOver = 1.2f;
    bool pressedState = false;
    public static bool checkD1 = true;
    public static bool checkD2 = true;
    public static bool checkD3 = true;

    void Update()
    {
        
        Vector3 objectPosition = transform.position;

        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            time = 0f;
            pressedState = true;
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha1) && objectPosition == heldZone1 && pressedState == true)
        {
            Drop();
            pressedState = false;
            checkD1 = true;
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha2) && objectPosition == heldZone2 && pressedState == true)
        {
            Drop();
            pressedState = false;
            checkD2 = true;
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha3) && objectPosition == heldZone3 && pressedState == true)
        {
            Drop();
            pressedState = false;
            checkD3 = true;
        }
    }

    void Drop()
    {
        objectToTeleport.transform.position = playerTransform.position;
        Debug.Log("Item dropped.");
    }
}