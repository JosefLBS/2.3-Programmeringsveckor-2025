using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public Transform Point1;
    public Transform Point2;
    public Transform Point3;

    public GameObject Player;

    public GameObject RedLayer;

    bool Detected = false;

    public float RoamingSpeed;
    public float HuntingSpeed;
    public float SearchingSpeed;

    bool Hunting = false;
    float HuntTime = 0;
    bool MonsterGrace = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
