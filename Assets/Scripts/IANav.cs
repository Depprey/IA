using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANav : MonoBehaviour {
    
    public Transform[] destination;

    public NavMeshAgent navMeshAgent;
    public Vector3 startPosition;
    public Animator anim;


    public GameObject saltito1;
    public GameObject saltito2;

    bool salto = false;

    int i=0;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("MEH NO HAY NAAA!");
        }
        startPosition = this.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {


        if (navMeshAgent.remainingDistance < 0.5f)
        { 
        navMeshAgent.destination = destination[i].position; 
        if (!navMeshAgent.pathPending)
        {
               // i = Random.Range(0, destination.Length);
           i =(i + 1) % destination.Length;
           // i++;
            if(i == destination.Length)
            {
                navMeshAgent.destination = startPosition;
             //   i = 0;
            }
        }
        }

    }

  void OnTriggerEnter(Collider other)
    {
        Debug.Log("HE ENTRADO EN EL TRIGGER");
        switch (other.tag)
        {
            case "salto":
                if(salto == false)
                {
                    salto = true;
                }
                else
                {
                    salto = false;
                }
                Debug.Log("HE ENTRADO EN EL COMPARETAG");
                anim.SetBool("Salto", salto);
                break;
            case "objeto":
                Debug.Log("HA ENTRADO AL COLLISION ENTER");
                other.gameObject.SetActive(false);
                GameObject SaltoActivable = GameObject.FindGameObjectWithTag("SaltoBueno");
                saltito1.SetActive(true);
                saltito2.SetActive(true);
                break;
           

        }
           
    }

  



}
