using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBox : MonoBehaviour
{
    // Daniel

    Player player;

    public GameObject PlayergameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayergameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Purple = true;
        }
    }
}
