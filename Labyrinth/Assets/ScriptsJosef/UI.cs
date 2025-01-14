using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Image Img; 
    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Img.enabled = false;  
    }
}
