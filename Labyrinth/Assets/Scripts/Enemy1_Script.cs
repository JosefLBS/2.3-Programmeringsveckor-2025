using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_Script : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public Transform spawnerPoint;

    public GameObject Player;

    public GameObject RedLayer;

    [SerializeField]
    AudioSource Scream;

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
        agent = GetComponent<NavMeshAgent>();

        Scream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = PlayerPosition.position;

        if (Hunting)
        {
            HuntTime += Time.deltaTime;

            RedLayer.SetActive(true);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, Mathf.Infinity))
        {
            if (hit.transform == Player.transform)
            {
                if (Hunting == false)
                {
                    Detected = true;

                    agent.speed = 0f;

                    Scream.enabled = true;
                }

                else if (MonsterGrace == false)
                {
                    agent.speed = HuntingSpeed;
                }
            }
            else if (hit.transform != Player.transform)
            {
                if (Detected == true)
                {
                    agent.speed = SearchingSpeed;
                }

                else if (Detected == false)
                {
                    agent.speed = RoamingSpeed;
                }
            }
        }

        if (Hunting == false)
        {
            if (Detected == true)
            {   
                HuntTime = 0;

                Hunting = true;

                MonsterGrace = true;
            }
        }

        if (HuntTime > 1)
        {
            MonsterGrace = false;
        }

        if (HuntTime > 4)
        {
            Scream.enabled = false;
        }
        
        if (HuntTime > 21)
        {
            HuntTime = 0f;

            RedLayer.SetActive(false);

            Detected = false;

            Hunting = false;

            agent.speed = 5f;

            gameObject.transform.position = spawnerPoint.position;
        }
    }
}
