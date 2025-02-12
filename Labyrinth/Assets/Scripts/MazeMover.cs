using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMover : MonoBehaviour
{
    // Daniel

    Items items;

    public GameObject ItemManager;

    public GameObject MoveGroup1;
    public GameObject MoveGroup2;

    public bool StartGame = false;

    public bool standingOnTop = false;

    public bool StartText;

    // Start is called before the first frame update
    void Start()
    {
        items = ItemManager.GetComponent<Items>();

        MoveGroup1.SetActive(false);
        MoveGroup2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {        
        if (standingOnTop == true && items.HasPickenUpKey == true)
        {
            StartGame = true;

            StartText = true;
        }
        
        if (StartGame == true)
        {
            MoveGroup1.SetActive(true);

            MoveGroup2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            standingOnTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            standingOnTop = false;
        }
    }
}
