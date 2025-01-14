using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_Script : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public GameObject Player;

    bool Detected = false;

    public float RoamingSpeed;
    public float HuntingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = PlayerPosition.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, Mathf.Infinity))
        {
            if (hit.transform == Player.transform)
            {
                Detected = true;
            }
            else if (hit.transform != Player.transform)
            {
                Detected = false;
            }
        }

        if (Detected == true)
        {
            agent.speed = HuntingSpeed;
        }

        if (Detected == false)
        {
            agent.speed = RoamingSpeed;
        }
    }
}
