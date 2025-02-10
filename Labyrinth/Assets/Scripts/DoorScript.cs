using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DoorScript : MonoBehaviour
{
    // Daniel

    public float Closetime;
    float Timer = 0;

    [SerializeField]
    NavMeshObstacle NMO;

    public GameObject ChildDoor;

    public GameObject PlayerGameObject;

    Player player;

    [SerializeField]
    BoxCollider boxcollider;


    
    // Start is called before the first frame update
    void Start()
    {
        NMO = GetComponent<NavMeshObstacle>();

        player = PlayerGameObject.GetComponent<Player>();

        boxcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        NMO.carving = true;
        
        RaycastHit hit;
        if (Physics.Raycast(PlayerGameObject.transform.position, PlayerGameObject.transform.forward, 5) == true)
        {
            if (Physics.Raycast(PlayerGameObject.transform.position, (PlayerGameObject.transform.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform == gameObject.transform)
                {
                    if (Input.GetKeyDown(KeyCode.F) && player.Key == true)
                    {
                        ChildDoor.transform.position -= new Vector3(0, 10f, 0);
                    }
                }
            }
        }

        if (ChildDoor.transform.position.y < 0)
        {
            NMO.enabled = false;

            boxcollider.enabled = false;
            
            Timer += Time.deltaTime;

            if (Timer > Closetime)
            {
                ChildDoor.transform.position += new Vector3(0, 10f, 0);

                NMO.enabled = true;

                boxcollider.enabled = true;

                Timer = 0;
            }
        }
    }
}
