using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SprintText : MonoBehaviour
{
    // Daniel
    
    [SerializeField]
    GameObject textGameObject;

    TextMeshProUGUI textComponent;

    bool Triggered = false;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = textGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Triggered)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                textComponent.text = ("");

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Triggered = true;

            textComponent.text = ("Press (Shift) To Sprint");
        }
    }
}
