using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurpleText : MonoBehaviour
{
    // Daniel
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    Player player;

    public GameObject PlayergameObject;

    public bool Done = false;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();

        player = PlayergameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Purple)
        {
            if (Done == false)
            {
                timer += Time.deltaTime;

                player.Started = false;

                if (timer > 18)
                {
                    Done = true;
                    
                    textComponent.text = ("");

                    player.Started = true;

                    Destroy(gameObject);
                }

                else if (timer > 15)
                {
                    textComponent.text = ("With This You Should Easily Be Able To Make It To The Exit At The End Of This Maze");
                }

                else if (timer > 12)
                {
                    textComponent.text = ("But Also The Power To Stun Enemies By Looking At Them");
                }

                else if (timer > 9)
                {
                    textComponent.text = ("This Does Not Just Give You The Blessing Of More Light");
                }

                else if (timer > 6)
                {
                    textComponent.text = ("The Power Of This Room Has Finally Granted Your Crystals The Power Of Combining");
                }

                else if (timer > 3)
                {
                    textComponent.text = ("But Fret Not Maze Breaker, Because You Won't Need Them");
                }

                else
                {
                    textComponent.text = ("Looks Like Your Items Disappeared And So Did The Entrance");
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Done = true;

                    textComponent.text = ("");

                    player.Started = true;

                    Destroy(gameObject);
                }
            }
        }
    }
}
