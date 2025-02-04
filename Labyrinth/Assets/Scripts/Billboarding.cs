using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    Vector3 CameraDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraDirection = Camera.main.transform.forward;
        CameraDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(CameraDirection);
    }
}
