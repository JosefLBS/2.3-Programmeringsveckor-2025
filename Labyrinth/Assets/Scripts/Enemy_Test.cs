using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Een : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public GameObject Player;

    bool Detected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = PlayerPosition.position;

        print(Detected);

        RaycastHit hit;
        if (Physics.Raycast(transform.position,(Player.transform.position-transform.position), out hit, Mathf.Infinity))
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
    }
}
