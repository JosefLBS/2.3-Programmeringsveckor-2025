using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BluePower : MonoBehaviour
{
    float Timer = 0;
    public float PowerTime;
    
    [SerializeField]
    NavMeshObstacle NMO;

    // Start is called before the first frame update
    void Start()
    {
        NMO.carving = true;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > PowerTime)
        {
            Destroy(gameObject);
        }
    }
}
