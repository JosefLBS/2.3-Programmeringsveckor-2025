using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Vector3 teleportDestination;
    public float interactionDistance = 5f;
    bool pressedState = false;
    public float time = 0f;
    public float timeOver = 0.5f;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressedState = true;
            time = Time.time;
            //TryTeleport();

           // if (time <= timeOver && )
            {

            }
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
        Debug.Log("Item get!");
    }





}