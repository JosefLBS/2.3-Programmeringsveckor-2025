using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_2 : MonoBehaviour
{
    Items items;

    [SerializeField] GameObject ItemManager;

    public bool Triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        ItemManager = GameObject.FindGameObjectWithTag("ItemManager");

        items = ItemManager.GetComponent<Items>();
    }

    private void Update()
    {
        if (Triggered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Triggered = false;
                
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            items.OnItem2 = false;

            Triggered = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            items.OnItem2 = true;

            Triggered = true;
        }
    }
}
