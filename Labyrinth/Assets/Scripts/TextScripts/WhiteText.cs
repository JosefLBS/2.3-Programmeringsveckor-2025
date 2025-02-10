using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class WhiteText : MonoBehaviour
{
    // Daniel
    
    [SerializeField] private Image BlackBackround;
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    Player player;

    public GameObject PlayergameObject;

    public bool startText = false;

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
        if (startText)
        {
            timer += Time.deltaTime;
            
            if (timer > 22)
            {
                Application.Quit();
            }
            
            else if (timer > 20)
            {
                BlackBackround.enabled = true;

                textComponent.color = Color.white;

                textComponent.text = ("Victory ?");
            }
            
            else if (timer > 17)
            {
                textComponent.text = ("Goodbye Maze Runner");
            }
            
            else if (timer > 14)
            {
                textComponent.text = ("Oh But Look At The Time, It Seems Like It's Time For Me To Bid Farewell");
            }
            
            else if (timer > 11)
            {
                textComponent.text = ("Too Bad You Won't Be There To Witness It As I Can't Afford To Ever Let You Out");
            }
            
            else if (timer > 8)
            {
                textComponent.text = ("And Know I'm Free To Do What Ever I Wish With These Powers That I Now Pocess;");
            }
            
            else if (timer > 5)
            {
                textComponent.text = ("I Don't Know Why All You Maze Breakers Decided To Help Me Out, But At Least Finally Someone Managed");
            }
            
            else if (timer > 2)
            {
                player.gameComplete = true;
                
                textComponent.color = Color.red;

                textComponent.text = ("For Saving Me The Trouble Of Doing It Myself");
            }

            else
            {
                textComponent.text = ("Thank You So Much Maze Breaker...");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startText = true;
        }
    }
}
