using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANav : MonoBehaviour {
    
    public Transform[] destination;

    public NavMeshAgent navMeshAgent;
    public Vector3 startPosition;
    public Animator anim;

    public GameObject x;

    public OffMeshLink saltito1;

    public float reachDist = 10f;
    public GameObject objetoX;


    bool cogioObjeto = false;
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
     
        if (cogioObjeto == false) { 
        float dist = Vector3.Distance(objetoX.transform.position, transform.position);
        if ( dist <= reachDist)
        {
            navMeshAgent.destination = objetoX.transform.position;
            if (!navMeshAgent.pathPending) {

                    CambioCoste y = x.GetComponent<CambioCoste>();
                    y.cambioCoste();
                    objetoX.SetActive(false);
                    navMeshAgent.destination = destination[i].position;
                    cogioObjeto = true;

            }
        }
        }

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
                anim.SetBool("Salto", salto);
                break;

            case "objeto":
                                
                other.gameObject.SetActive(false);                
                saltito1.activated = true;               
                break;

            case "puerta":

                puerta xx = other.gameObject.GetComponent<puerta>();
                xx.abrirPuerta();
                break;



        }
           
    }

  



}
