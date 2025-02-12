using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Enemy1_Script : MonoBehaviour
{
    // Daniel

    public Transform PlayerPosition;
    private NavMeshAgent agent;

    public GameObject RestPoint;

    public bool napTime;

    public GameObject PlayerGameObject;

    public GameObject RedLayer;

    [SerializeField]
    Animator animator;

    bool Detected = false;

    public float RoamingSpeed;
    public float HuntingSpeed;
    public float SearchingSpeed;

    public bool Hunting = false;
    public float HuntTime = 0;
    bool MonsterGrace = false;

    AudioSource[] audioSources;

    Items items;

    public GameObject ItemManager;

    [SerializeField] BoxCollider boxCollider;

    AggroBoxes Aggro;

    public GameObject aggresive;

    [SerializeField] private Image JumpScare;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        audioSources = GetComponents<AudioSource>();

        animator = GetComponent<Animator>();

        items = ItemManager.GetComponent<Items>();

        boxCollider = GetComponent<BoxCollider>();

        Aggro = aggresive.GetComponent<AggroBoxes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Aggro.Aggresive == false)
        {
            agent.destination = RestPoint.transform.position;

            agent.speed = 15;

            audioSources[1].enabled = false;

            if (HuntTime < 22)
            {
                RedLayer.SetActive(false);

                HuntTime = 23;
            }
        }
        
        if (Aggro.Aggresive == true)
        {
            if (items.RadioUsing == true)
            {
                agent.destination = items.RadioPosition;

                agent.speed = HuntingSpeed;
            }

            if (napTime == true)
            {
                agent.destination = RestPoint.transform.position;

                agent.speed = 15;

                if (gameObject.transform.position.x == RestPoint.transform.position.x && gameObject.transform.position.z == RestPoint.transform.position.z)
                {
                    napTime = false;
                }
            }

            if (items.RadioUsing == false)
            {
                if (Hunting)
                {
                    HuntTime += Time.deltaTime;

                    RedLayer.SetActive(true);
                }

                if (napTime == false)
                {
                    agent.destination = PlayerPosition.position;

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, (PlayerGameObject.transform.position - transform.position), out hit, Mathf.Infinity))
                    {
                        if (hit.transform == PlayerGameObject.transform)
                        {
                            audioSources[1].enabled = true;

                            if (Hunting == false)
                            {
                                Detected = true;

                                agent.speed = 0f;

                                animator.SetBool("GracePeriod", true);

                                audioSources[0].enabled = true;
                            }

                            else if (MonsterGrace == false)
                            {
                                agent.speed = HuntingSpeed;
                            }
                        }
                        else if (hit.transform != PlayerGameObject.transform)
                        {
                            audioSources[1].enabled = false;

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

                        Detected = false;

                        Hunting = false;

                        agent.speed = 5f;

                        napTime = true;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Radio")
        {
            items.RadioUsing = false;

            Destroy(other.gameObject);
        }

        if (other.tag == "Player" && items.RadioUsing == false)
        {
            JumpScare.enabled = true;
        }
    }
}
