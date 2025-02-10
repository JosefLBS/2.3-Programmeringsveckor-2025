using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastAggroBox : MonoBehaviour
{
    // Daniel
    
    AggroBoxes Aggro;

    public GameObject Aggresive;

    // Start is called before the first frame update
    void Start()
    {
        Aggro = Aggresive.GetComponent<AggroBoxes>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Aggro.Aggresive = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Aggro.Aggresive = true;
        }
    }
}
