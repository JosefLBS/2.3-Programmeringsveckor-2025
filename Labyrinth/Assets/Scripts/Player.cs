using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    float PlayerRotation = 0;

    bool PossibleToPressButton = true;

    bool TurnRight = false;

    float Timer = 0;

    public int TimerSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        
        if (PossibleToPressButton)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                PossibleToPressButton = false;

                PlayerRotation += 90;

                Timer = 0;

                TurnRight = true;
            }
        }

        if (TurnRight == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, PlayerRotation - 45, 0));

            if (Timer > 0.2f)
            {
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, PlayerRotation, 0));

                TurnRight = false;

                PossibleToPressButton = true;
            }
        }
    }   
}
