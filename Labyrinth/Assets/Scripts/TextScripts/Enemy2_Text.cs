using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy2_Text : MonoBehaviour
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

            if (timer > 22)
            {
                textComponent.text = ("");

                player.Started = true;

                Destroy(gameObject);
            }

            else if (timer > 18)
            {
                textComponent.text = ("And As A Last Piece Of Advice, While Hiding, Don't Run Or They Will Hear");
            }

            else if (timer > 14)
            {
                textComponent.text = ("Also When You Hear Crying, That Means That The Monster Has Temporary Given Up, Just Make Sure It Doesn't See You");
            }
            
            else if (timer > 10)
            {
                textComponent.text = ("When That Happens Hide, But Make Sure That They Don't See Where You Go, Or Else They Will Follow");
            }

            else if (timer > 7)
            {
                textComponent.text = ("When You Hear Singing, Then They're After You");
            }

            else if (timer > 4)
            {
                textComponent.text = ("When You Hear Whispers, That Means They Are Near");
            }

            else if (timer > 2)
            {
                textComponent.text = ("The Crawlers Do Not Mess Around");
            }

            else
            {
                textComponent.text = ("Be Warned Maze Runner");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                textComponent.text = ("");

                player.Started = true;

                Destroy(gameObject);
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
