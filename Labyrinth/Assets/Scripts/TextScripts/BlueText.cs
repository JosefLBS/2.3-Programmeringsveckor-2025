using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BlueText : MonoBehaviour
{
    // Daniel
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    Player player;

    public GameObject PlayergameObject;

    public bool Done = false;

    float timer = 0;

    RedText redText;

    public GameObject rGameObject;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();

        player = PlayergameObject.GetComponent<Player>();

        redText = rGameObject.GetComponent<RedText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bCrystal)
        {            
            if (Done == false)
            {
                timer += Time.deltaTime;

                player.Started = false;

                if (timer > 9)
                {
                    if (redText.Done == true)
                    {                        
                        if (timer > 15)
                        {
                            Done = true;
                            
                            textComponent.text = ("");

                            player.Started = true;
                        }

                        else if (timer > 12)
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
                    textComponent.text = ("Which In This Case Is Manifesting A Temporary Blue Wall, That You And Only You Can Walk Through");
                }
                
                else if (timer > 2)
                {
                    textComponent.text = ("You Can Activate It's Power Anytime By Pressing (Z) If The Crystal Is Ready");
                }

                else
                {
                    textComponent.text = ("Congrats Maze Breaker, You Found The Blue Crystal");
                }
            }
        }
    }
}
