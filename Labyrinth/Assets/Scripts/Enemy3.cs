using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public Transform spawnerPoint;

    public GameObject PlayerGameObject;

    [SerializeField]
    Animator animator;

    bool Detected = false;

    public float RunningSpeed;
    public float CreepingSpeed;

    bool Stunned = false;

    bool Activating = false;
    public float ActivationTime;
    float Activation_timer;

    AudioSource[] audioSources;

    float Stun_timer;
    public float StunTime;

    public float JinnRange; //Based of the Phasmophobia Jinn Ghost

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        audioSources = GetComponents<AudioSource>();

        animator = GetComponent<Animator>();

        agent.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Activating == true)
        {
            audioSources[2].enabled = true;

            Activation_timer += Time.deltaTime;

            if (Activation_timer > 7)
            {
                Activating = false;

                audioSources[2].enabled = false;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (PlayerGameObject.transform.position - transform.position), out hit, Mathf.Infinity))
        {         
            if (Stunned == false)
            {
                if (hit.transform == PlayerGameObject.transform)
                {
                    if (Activation_timer > ActivationTime)
                    {                     
                        agent.speed = RunningSpeed;

                        audioSources[0].enabled = false;

                        audioSources[1].enabled = true;
                    }

                    else
                    {
                        Activating = true;

                        Detected = true;
                    }
                }

                if (hit.transform != PlayerGameObject.transform && Detected == true)
                {
                    agent.speed = CreepingSpeed;

                    audioSources[1].enabled = false;

                    audioSources[0].enabled = true;
                }
            }
        }

        if (Detected == true && Stunned == false && Activation_timer > ActivationTime)
        {
            agent.destination = PlayerPosition.position;
        }

        if (Physics.Raycast(PlayerGameObject.transform.position, (PlayerGameObject.transform.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform == gameObject.transform)
            {
                Stunned = true;

                Stun_timer = 0;

                agent.speed = 0f;
            }
        }

        if (Stunned)
        {
            animator.SetBool("Stunned", true);
            
            audioSources[0].enabled = false;
            audioSources[1].enabled = false;
            
            Stun_timer += Time.deltaTime;

            if (Stun_timer > StunTime)
            {
                animator.SetBool("Stunned", false);
                
                Stunned = false;
            }
        }
    }
}
