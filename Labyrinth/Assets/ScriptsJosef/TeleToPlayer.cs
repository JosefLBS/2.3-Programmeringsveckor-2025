using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleToPlayer : MonoBehaviour
{
    public GameObject objectToTeleport;
    public Transform playerTransform;
    public KeyCode teleportButton = KeyCode.Q;
    public Vector3 heldZone;
    //Vector3 heldZone = new Vector3(5, 5, 5);

    void Update()
    {
        Vector3 objectPosition = transform.position;

        if (objectPosition == heldZone)
        if (Input.GetKeyDown(teleportButton))
        {
            TeleportObject();
        }
    }

    void TeleportObject()
    {
        objectToTeleport.transform.position = playerTransform.position;
        Debug.Log("Item dropped.");
    }
}