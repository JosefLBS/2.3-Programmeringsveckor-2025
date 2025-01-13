using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Vector3 teleportDestination;
    public float interactionDistance = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryTeleport();
        }
    }

    void TryTeleport()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Teleport();
            }
        }
    }

    void Teleport()
    {
        transform.position = teleportDestination;
        Debug.Log("Object teleported!");
    }
}