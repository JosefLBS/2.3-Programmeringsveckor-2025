using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Items : MonoBehaviour
{
    // Daniel && Josef

    public Color RedColor;
    public Color GreenColor;

    Player player;

    public GameObject PlayerGameObject;

    public GameObject MovingRadio;

    int[] items = new int[3];

    [SerializeField] private Image Slot1;
    [SerializeField] private Image Slot2;
    [SerializeField] private Image Slot3;

    // SLot1 ITEMS

    [SerializeField] private Image EnergyBar1;
    [SerializeField] private Image Radio1;
    [SerializeField] private Image Key1;

    // Slot2 ITEMS

    [SerializeField] private Image EnergyBar2;
    [SerializeField] private Image Radio2;
    [SerializeField] private Image Key2;

    // Slot3 ITEMS

    [SerializeField] private Image EnergyBar3;
    [SerializeField] private Image Radio3;
    [SerializeField] private Image Key3;

    bool HoveringSlot1 = true, HoveringSlot2 = false, HoveringSlot3 = false;

    public bool OnItem1 = false, OnItem2 = false, OnItem3 = false;

    public bool RadioUsing = false;

    public Vector3 RadioPosition;

    [SerializeField]
    public GameObject EnergyBar_Item;

    [SerializeField]
    public GameObject Radio_Item;

    [SerializeField]
    public GameObject Key_Item;

    public bool HasPickenUpKey = false;

    public bool HasPickenUpEnergyBar = false;

    [SerializeField] GameObject Radio;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerGameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() 
    {      
        
        if (player.Purple == true)
        {
            items[0] = 0;
            items[1] = 0;
            items[2] = 0;

            Slot1.enabled = false;
            Slot2.enabled = false;
            Slot3.enabled = false;
        }
        
        // Switching Slots
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HoveringSlot1 = true;

            HoveringSlot2 = false;
            HoveringSlot3 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HoveringSlot2 = true;

            HoveringSlot1 = false;
            HoveringSlot3 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HoveringSlot3 = true;

            HoveringSlot1 = false;
            HoveringSlot2 = false;
        }

        // On SLOT ONE
        
        if (HoveringSlot1)
        {
            Slot1.color = RedColor;

            // What Item Is It??
            
            if (OnItem1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[0] != 0)
                    {
                        Replace();
                    }

                    items[0] = 1;

                    EnergyBar1.enabled = true;

                    OnItem1 = false;
                }
            }

            if (OnItem2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[0] != 0)
                    {
                        Replace();
                    }

                    items[0] = 2;

                    Radio1.enabled = true;

                    OnItem2 = false;
                }
            }

            if (OnItem3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[0] != 0)
                    {
                        Replace();
                    }

                    items[0] = 3;

                    Key1.enabled = true;

                    OnItem3 = false;
                }
            }

            // Using The Item 

            if (items[0] == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    player.Stamina = 100;

                    EnergyBar1.enabled = false;

                    items[0] = 0;
                }              
            }

            if (items[0] != 1)
            {
                EnergyBar1.enabled = false;
            }

            if (items[0] == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (RadioUsing)
                    {
                        Radio = GameObject.FindGameObjectWithTag("Radio");

                        Destroy(Radio);
                    }
                    
                    RadioUsing = true;

                    Instantiate(MovingRadio, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);

                    RadioPosition = new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z);

                    Radio1.enabled = false;
                }
            }

            if (items[0] != 2)
            {
                Radio1.enabled = false;
            }

            if (items[0] == 3)
            {
                player.Key = true;
            }

            if (items[0] != 3)
            {
                player.Key = false;

                Key1.enabled = false;
            }
        }

        else
        {
            Slot1.color = GreenColor;

            if (items[0] == 3)
            {
                player.Key = false;
            }
        }

        // On SLOT TWO

        if (HoveringSlot2)
        {
            Slot2.color = RedColor;

            // What Item Is It??

            if (OnItem1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[1] != 0)
                    {
                        Replace();
                    }

                    items[1] = 1;

                    EnergyBar2.enabled = true;

                    OnItem1 = false;
                }
            }

            if (OnItem2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[1] != 0)
                    {
                        Replace();
                    }

                    items[1] = 2;

                    Radio2.enabled = true;

                    OnItem2 = false;
                }
            }

            if (OnItem3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[1] != 0)
                    {
                        Replace();
                    }

                    items[1] = 3;

                    Key2.enabled = true;

                    OnItem3 = false;
                }
            }

            // Using The Item 

            if (items[1] == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    player.Stamina = 100;

                    EnergyBar2.enabled = false;

                    items[1] = 0;
                }
            }

            if (items[1] != 1)
            {
                EnergyBar2.enabled = false;
            }

            if (items[1] == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (RadioUsing)
                    {
                        Radio = GameObject.FindGameObjectWithTag("Radio");

                        Destroy(Radio);
                    }

                    RadioUsing = true;

                    Instantiate(MovingRadio, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);

                    RadioPosition = new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z);

                    Radio2.enabled = false;
                }
            }

            if (items[1] != 2)
            {
                Radio2.enabled = false;
            }

            if (items[1] == 3)
            {
                player.Key = true;
            }

            if (items[1] != 3)
            {
                player.Key = false;

                Key2.enabled = false;
            }
        }

        else
        {
            Slot2.color = GreenColor;

            if (items[1] == 3)
            {
                player.Key = false;
            }
        }

        // On SLOT THREE

        if (HoveringSlot3)
        {
            Slot3.color = RedColor;

            // What Item Is It??

            if (OnItem1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[2] != 0)
                    {
                        Replace();
                    }

                    items[2] = 1;

                    EnergyBar3.enabled = true;

                    OnItem1 = false;
                }
            }

            if (OnItem2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[2] != 0)
                    {
                        Replace();
                    }

                    items[2] = 2;

                    Radio3.enabled = true;

                    OnItem2 = false;
                }
            }

            if (OnItem3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (items[2] != 0)
                    {
                        Replace();
                    }

                    items[2] = 3;

                    Key3.enabled = true;

                    OnItem3 = false;
                }
            }

            // Using The Item 

            if (items[2] == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    player.Stamina = 100;

                    EnergyBar3.enabled = false;

                    items[2] = 0;
                }
            }

            if (items[2] != 1)
            {
                EnergyBar3.enabled = false;
            }

            if (items[2] == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (RadioUsing)
                    {
                        Radio = GameObject.FindGameObjectWithTag("Radio");

                        Destroy(Radio);
                    }

                    RadioUsing = true;

                    Instantiate(MovingRadio, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);

                    RadioPosition = new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z);

                    Radio3.enabled = false;
                }
            }

            if (items[2] != 2)
            {
                Radio3.enabled = false;
            }

            if (items[2] == 3)
            {
                player.Key = true;
            }

            if (items[2] != 3)
            {
                player.Key = false;

                Key3.enabled = false;
            }
        }

        else
        {
            Slot3.color = GreenColor;

            if (items[2] == 3)
            {
                player.Key = false;
            }
        }

        if (items[0] == 3 || items[1] == 3 || items[2] == 3)
        {
            HasPickenUpKey = true;
        }

        if (items[0] == 1 || items[1] == 1 || items[2] == 1)
        {
            HasPickenUpEnergyBar = true;
        }
    }

    public void Replace()
    {
        if (HoveringSlot1)
        {
            if (items[0] == 1)
            {
                Instantiate(EnergyBar_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[0] == 2)
            {
                Instantiate(Radio_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[0] == 3)
            {
                Instantiate(Key_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }
        }

        if (HoveringSlot2)
        {
            if (items[1] == 1)
            {
                Instantiate(EnergyBar_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[1] == 2)
            {
                Instantiate(Radio_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[1] == 3)
            {
                Instantiate(Key_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }
        }

        if (HoveringSlot3)
        {
            if (items[2] == 1)
            {
                Instantiate(EnergyBar_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[2] == 2)
            {
                Instantiate(Radio_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }

            if (items[2] == 3)
            {
                Instantiate(Key_Item, new Vector3(PlayerGameObject.transform.position.x, 3f, PlayerGameObject.transform.position.z), Quaternion.identity);
            }
        }
    }
}
