using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANav : MonoBehaviour {
    
    public Transform[] destination;

    public NavMeshAgent navMeshAgent;
    public Vector3 startPosition;

    int i=0;

	// Use this for initialization
	void Start () {

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
            // i =(i + 1) % destination.Length;
            i++;
            if(i == destination.Length)
            {
                navMeshAgent.destination = startPosition;
                i = 0;
            }
        }
        }

    }
}
