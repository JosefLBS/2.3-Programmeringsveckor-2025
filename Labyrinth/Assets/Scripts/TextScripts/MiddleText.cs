using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiddleText : MonoBehaviour
{
    // Daniel
    
    MazeMover maze;

    bool TextStarted;

    float timer = 0;

    public GameObject Enemy1_Text;
    public GameObject Enemy2_Text;

    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    bool Done;

    // Start is called before the first frame update
    void Start()
    {
        maze = GetComponent<MazeMover>();

        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maze.StartText)
        {
            if (Done == false)
            {
                timer += Time.deltaTime;

                if (timer > 10)
                {
                    textComponent.text = ("");

                    Enemy1_Text.SetActive(true);
                    Enemy2_Text.SetActive(true);

                    Done = true;
                }

                else if (timer > 6)
                {
                    textComponent.text = ("I Must Warn You, It Is Hard To Clear The Red Path Without The Blue Crystal");
                }

                else if (timer > 3)
                {
                    textComponent.text = ("The, Maze Has Shifted And You Now Have Two Ways To Go");
                }

                else
                {
                    textComponent.text = ("WoW, Maze Breaker Look Behind You");
                }
            }
        }
    }
}
