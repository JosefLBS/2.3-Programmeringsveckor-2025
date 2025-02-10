using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BluePower : MonoBehaviour
{
    // Daniel

    [SerializeField]
    NavMeshObstacle NMO;

    [SerializeField]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        NMO = GetComponent<NavMeshObstacle>();
        
        NMO.carving = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
