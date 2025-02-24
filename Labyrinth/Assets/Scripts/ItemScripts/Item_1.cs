using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item_1 : MonoBehaviour
{
    // Daniel && Josef
    
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
            items.OnItem1 = false;

            Triggered = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            items.OnItem1 = true;

            Triggered = true;
        }
    }
}
