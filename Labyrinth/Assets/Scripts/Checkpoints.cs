using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    Player player;
    
    public GameObject PlayerGameObject;

    public Transform SpwanPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerGameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Spawn = SpwanPoint;
        }
    }
}
