using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_Script : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public Transform spawnerPoint;

    public GameObject PlayerGameObject;

    public GameObject RedLayer;

    [SerializeField]
    Animator animator;

    bool Detected = false;

    public float RoamingSpeed;
    public float HuntingSpeed;
    public float SearchingSpeed;

    bool Hunting = false;
    float HuntTime = 0;
    bool MonsterGrace = false;

    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        audioSources = GetComponents<AudioSource>();

        animator = GetComponent<Animator>();
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
        if (Physics.Raycast(transform.position, (PlayerGameObject.transform.position - transform.position), out hit, Mathf.Infinity))
        {
            if (hit.transform == PlayerGameObject.transform)
            {
                if (Hunting == false)
                {
                    Detected = true;

                    agent.speed = 0f;

                    animator.SetBool("GracePeriod", true);

                    audioSources[0].enabled = true;

                    audioSources[1].enabled = true;
                }

                else if (MonsterGrace == false)
                {
                    agent.speed = HuntingSpeed;
                }
            }
            else if (hit.transform != PlayerGameObject.transform)
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

            animator.SetBool("GracePeriod", false);
        }

        if (HuntTime > 4)
        {
            audioSources[0].enabled = false;
        }
        
        if (HuntTime > 21)
        {
            HuntTime = 0f;

            RedLayer.SetActive(false);

            audioSources[1].enabled = false;

            Detected = false;

            Hunting = false;

            agent.speed = 5f;

            gameObject.transform.position = spawnerPoint.position;
        }
    }
}
