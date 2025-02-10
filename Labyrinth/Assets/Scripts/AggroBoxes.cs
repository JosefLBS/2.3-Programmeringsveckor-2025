using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroBoxes : MonoBehaviour
{
    // Daniel
    
    public bool Aggresive = false;

    MazeMover maze;

    public GameObject mazeMover;

    Items items;

    public GameObject ItemManager;

    [SerializeField] GameObject Radio;
    
    // Start is called before the first frame update
    void Start()
    {
        maze = mazeMover.GetComponent<MazeMover>();

        items = ItemManager.GetComponent<Items>();
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

            if (items.RadioUsing == true)
            {
                Radio = GameObject.FindGameObjectWithTag("Radio");

                items.RadioUsing = false;

                Destroy(Radio);
            }
        }
    }
}
