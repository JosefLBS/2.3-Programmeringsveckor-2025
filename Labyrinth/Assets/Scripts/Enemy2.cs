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

    public GameObject PlayerGameObject;

    public float HearingRange;
    public float DetectionRange;

    bool Detected = false;
    bool LOS = false;

    public float PatrolSpeed;
    public float SearchingSpeed;
    public float LOS_Speed;

    bool Hunting = false;
    bool Searching = false;
    float SearchTime = 10;

    Vector3 NextPoint;

    Player player;

    AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerGameObject.GetComponent<Player>();
        
        agent = GetComponent<NavMeshAgent>();

        audioSources = GetComponents<AudioSource>();

        NextPoint = Point1.position;

        agent.speed = PatrolSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Patrol and detection
        
        if (Detected == false && Hunting == false)
        {
            audioSources[1].enabled = false;
            
            agent.destination = NextPoint;

            agent.speed = PatrolSpeed;

            if (Vector3.Distance(transform.position, PlayerGameObject.transform.position) < HearingRange)
            {
                if (Vector3.Distance(transform.position, PlayerGameObject.transform.position) < DetectionRange)
                {
                    Detected = true;
                }

                else
                {
                    audioSources[0].enabled = true;
                }
            }
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

        // After Being Detected
        
        if (Detected == true)
        {
            audioSources[0].enabled = false;
            audioSources[1].enabled = true;
            
            if (Hunting == false || LOS == true)
            {
                agent.destination = PlayerPosition.position;
            }

            if (Hunting == false)
            {
                agent.speed = LOS_Speed;
            }

            if (Hunting == true && LOS == false && player.Sprinting == false)
            {
                agent.speed = SearchingSpeed;
            }
        }

        // Line Of Sigth --> LOS
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (PlayerGameObject.transform.position - transform.position), out hit, Mathf.Infinity))
        {
            if (hit.transform == PlayerGameObject.transform)
            {
                Hunting = true;

                Detected = true;

                LOS = true;

                Searching = false;

                audioSources[1].volume = 1;
            }

            if (hit.transform != PlayerGameObject.transform && player.Sprinting == false && Hunting == true)
            {
                LOS = false;

                audioSources[1].volume = 0.3f;

                agent.speed = SearchingSpeed;

                if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                {
                    if (Searching == false)
                    {
                        SearchTime = 0f;
                    }

                    Searching = true;
                }
            }
        }

        // During Hunts

        if (Hunting)
        {
            if (player.Sprinting && player.Moving)
            {
                agent.destination = PlayerPosition.position;

                agent.speed = LOS_Speed;

                Searching = false;
            }

            if (player.Sprinting == false && LOS == false)
            {
                agent.speed = SearchingSpeed;
            }
        }

        // While Searching
        
        if (Searching == true)
        {
            SearchTime += Time.deltaTime;

            if (SearchTime > 10f)
            {
                Searching = false;

                Detected = false;

                Hunting = false;
            }
        }
    }
}
