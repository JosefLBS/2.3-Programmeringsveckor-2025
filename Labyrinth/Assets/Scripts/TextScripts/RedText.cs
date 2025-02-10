using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedText : MonoBehaviour
{
    // Daniel
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    Player player;

    public GameObject PlayergameObject;

    public bool Done = false;

    float timer = 0;

    BlueText blueText;

    public GameObject bGameObject;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();

        player = PlayergameObject.GetComponent<Player>();

        blueText = bGameObject.GetComponent<BlueText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.rCrystal)
        {
            if (Done == false)
            {
                timer += Time.deltaTime;

                player.Started = false;

                if (timer > 8)
                {
                    if (blueText.Done == true)
                    {
                        if (timer > 14)
                        {
                            Done = true;

                            textComponent.text = ("");

                            player.Started = true;
                        }

                        else if (timer > 11)
                        {
                            textComponent.text = ("You Should Probably Head Back Towards The Middle Ground Now");
                        }

                        else
                        {
                            textComponent.text = ("Well Done Maze Breaker, You Found Both Crystals");
                        }
                    }

                    else
                    {
                        Done = true;

                        textComponent.text = ("");

                        player.Started = true;
                    }
                }

                else if (timer > 5)
                {
                    textComponent.text = ("Which In This Case Is Grants You The Power To Walk Through (Gray Brick Walls) And (Gates)");
                }

                else if (timer > 2)
                {
                    textComponent.text = ("You Can Activate It's Power Anytime By Pressing (X) If The Crystal Is Ready");
                }

                else
                {
                    textComponent.text = ("Congrats Maze Breaker, You Found The Red Crystal");
                }
            }
        }
    }
}
