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

    Vector3 NextPoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        NextPoint = Point1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Detected == false)
        {
            agent.destination = NextPoint;
        }
        
        if (gameObject.transform.position.x == Point1.position.x && gameObject.transform.position.z == Point1.position.z)
        {
            NextPoint = Point2.position;
        }

        if (gameObject.transform.position.x == Point2.position.x && gameObject.transform.position.z == Point2.position.z)
        {
            NextPoint = Point3.position;
        }

        if (gameObject.transform.position.x == Point3.position.x && gameObject.transform.position.z == Point3.position.z)
        {
            NextPoint = Point1.position;
        }
    }
}
