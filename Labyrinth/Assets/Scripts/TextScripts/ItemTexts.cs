using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ItemTexts : MonoBehaviour
{
    // Daniel
    
    Items items;

    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    bool Done;

    public GameObject EnergyBar;

    float timer = 0;

    bool PressedF = false;

    // Start is called before the first frame update
    void Start()
    {
        items = GetComponent<Items>();

        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Done == false)
        {
            if (items.HasPickenUpEnergyBar)
            {
                timer += Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.F) && PressedF == false)
                {
                    timer = 0;
                    
                    PressedF = true;
                }

                if (timer > 3)
                {
                    textComponent.text = ("Also Look Out For Radios, They Can Distract Monsters");

                    if (timer > 6)
                    {
                        textComponent.text = ("");
                        
                        Done = true;
                    }
                }
                
                else if (PressedF == true)
                {
                    textComponent.text = ("Just Like That, But Remember To Have The Right Slot Selected");
                }
                

                else
                {
                    textComponent.text = ("Press F To Use Items");
                }
            }

            else if (items.OnItem1 == true)
            {
                timer = 0;

                textComponent.text = ("Don't Worry About An Occupied Slot As You Can Always Replace An Item By Pressing E");
            }

            else if (items.HasPickenUpKey)
            {
                timer += Time.deltaTime;

                if (timer > 3)
                {
                    textComponent.text = ("I See That You Are Tired, Try Eating The EnergyBar behind You");

                    EnergyBar.SetActive(true);
                }

                else
                {
                    textComponent.text = ("Good Job, You Can Change The Slot By Pressing The Number Of The Corresponding Slot");
                }
            }

            else if (items.OnItem3)
            {
                textComponent.text = ("There It Is, While Standing On It Press (E) To Pick It Up");
            }
        }
    }
}
