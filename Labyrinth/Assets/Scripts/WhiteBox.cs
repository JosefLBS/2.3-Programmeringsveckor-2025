using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBox : MonoBehaviour
{
    // Daniel
    
    public GameObject WhiteDoor;
    
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
        if (other.tag == "Player")
        {
            WhiteDoor.SetActive(true);
        }
    }
}
