using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    // Josef
    
    public Vector3 teleportDestination;
    public float interactionDistance = 5f;
    bool pressedState = false;
    public float time = 0f;
    public float timeOver = 0.5f;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    bool Item1Slot1 = false;
    bool Item1Slot2 = false;
    bool Item1Slot3 = false;

    bool Item2Slot1 = false;
    bool Item2Slot2 = false;
    bool Item2Slot3 = false;

    bool Item3Slot1 = false;
    bool Item3Slot2 = false;
    bool Item3Slot3 = false;

    private void Start()
    {
       
    }

    void Update()
    {

        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            time = 0f;
            pressedState = true;
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha1) && pressedState == true)
        {
            if (TeleToPlayer.checkD1 == true)
            {
                TryTeleport1(new Vector3(5, 5, 5));
                pressedState = false;
            }
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha2) && pressedState == true)
        {
            if (TeleToPlayer.checkD2 == true)
            {
                TryTeleport2(new Vector3(7, 7, 7));
                pressedState = false;
            }
        }

        if (time <= timeOver && Input.GetKeyDown(KeyCode.Alpha3) && pressedState == true)
        {
            if (TeleToPlayer.checkD3 == true)
            {
                TryTeleport3(new Vector3(9, 9, 9));
                pressedState = false;
            }
        }
    }



    void TryTeleport1(Vector3 target)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Teleport1(target);
            }
        }
    }

    void TryTeleport2(Vector3 target)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Teleport2(target);
            }
        }
    }

    void TryTeleport3(Vector3 target)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Teleport3(target);
            }
        }
    }
    private void Teleport1(Vector3 target)
    {
        transform.position = target;
        Debug.Log("Item get!");
        TeleToPlayer.checkD1 = false;
        if (Item1.transform.position == target)
        {
            Debug.Log("Currently in slot 1: Item 1");
            Item1Slot1 = true;
        }
        if (Item2.transform.position == target)
        {
            Debug.Log("Currently in slot 1: Item 2");
            Item2Slot1 = true;
        }
        if (Item3.transform.position == target)
        {
            Debug.Log("Currently in slot 1: Item 3");
            Item3Slot1 = true;
        }
    }

    private void Teleport2(Vector3 target)
    {
        transform.position = target;
        Debug.Log("Item get!");
        TeleToPlayer.checkD2 = false;
        if(Item1.transform.position == target)
        {
            Debug.Log("Currently in slot 2: Item 1");
            Item1Slot2 = true;
        }
        if (Item2.transform.position == target)
        {
            Debug.Log("Currently in slot 2: Item 2");
            Item2Slot2 = true;
        }
        if (Item3.transform.position == target)
        {
            Debug.Log("Currently in slot 2: Item 3");
            Item3Slot2 = true;
        }
    }

    private void Teleport3(Vector3 target)
    {
        transform.position = target;
        Debug.Log("Item get!");
        TeleToPlayer.checkD3 = false;
        if (Item1.transform.position == target)
        {
            Debug.Log("Currently in slot 3: Item 1");
            Item1Slot3 = true;
        }
        if (Item2.transform.position == target)
        {
            Debug.Log("Currently in slot 3: Item 2");
            Item2Slot3 = true;
        }
        if (Item3.transform.position == target)
        {
            Debug.Log("Currently in slot 3: Item 3");
            Item3Slot3 = true;
        }
    }
}