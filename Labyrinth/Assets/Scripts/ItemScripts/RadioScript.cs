using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    Items items;

    [SerializeField] GameObject ItemManager;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("Collision");
            
            items.RadioUsing = false;

            Destroy(gameObject);
        }
    }
}
