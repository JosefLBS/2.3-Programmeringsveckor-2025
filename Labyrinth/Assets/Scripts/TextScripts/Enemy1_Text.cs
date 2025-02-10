using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Daniel
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    Player player;

    public GameObject PlayerGameObject;

    bool startText = false;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();

        player = PlayerGameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startText)
        {
            timer += Time.deltaTime;

            if (timer > 12)
            {
                textComponent.text = ("");

                player.Started = true;

                Destroy(gameObject);
            }

            else if (timer > 8)
            {
                textComponent.text = ("That Will Be Your Chance, Also Note That They Lose Speed With Out LINE OF SIGHT");
            }

            else if (timer > 4)
            {
                textComponent.text = ("When They Find You, You Run, Survive Long Enough And They'll Go back To Their Nest For A Little While");
            }

            else if (timer > 2)
            {
                textComponent.text = ("The Stalkers Do Not Mess Around");
            }

            else
            {
                textComponent.text = ("Be Warned Maze Breaker");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Started = false;

            startText = true;
        }
    }
}
