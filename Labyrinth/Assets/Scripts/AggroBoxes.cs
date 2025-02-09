using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroBoxes : MonoBehaviour
{
    public bool Aggresive = false;

    MazeMover maze;

    public GameObject mazeMover;
    
    // Start is called before the first frame update
    void Start()
    {
        maze = mazeMover.GetComponent<MazeMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (maze.StartGame == true)
        {
            if (other.tag == "Player")
            {
                Aggresive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Aggresive = false;
        }
    }
}
