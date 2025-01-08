using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{

    float PlayerRotation = 0;

    bool PossibleToPressButton = true;

    bool TurnRight = false;

    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * 6;
        
        if (PossibleToPressButton)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                PossibleToPressButton = false;

                TurnRight = true;

                Timer = 0;

                PlayerRotation += 90;
            }
        }

        if (TurnRight == true)
        {
            for (float i = 0; i < PlayerRotation; i += Timer)
            {
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, PlayerRotation, 0));
            }

            PossibleToPressButton = true;

            TurnRight = false;
        }
    }   
}
