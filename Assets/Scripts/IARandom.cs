using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IARandom : MonoBehaviour
{

    public Transform[] destination;

    public NavMeshAgent navMeshAgent;
    public Vector3 startPosition;
    public Animator anim;

    public GameObject x;

    public OffMeshLink saltito1;

    public float reachDist = 10f;
    public GameObject objetoX;


    bool cogioObjeto = false;

    bool finBucle = false;
    int i = 0;

    // Use this for initialization
    void Start()
    {
        // GUARDAMOS EN VARIABLES LOS COMPONENTES DE ANIMATOR Y NAVMESH AGENT
        anim = GetComponent<Animator>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("MEH NO HAY NAAA!");
        }
        startPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // ESTABLECEMOS LA ANIMACION CON LA VELOCIDAD DE LA IA
        anim.SetFloat("velocidad", navMeshAgent.speed);

        // ESTE BUCLE BUSCA EL OBJETO QUE TIENE QUE COGER, SI ESTA CERCA VA A POR EL.
        if (cogioObjeto == false)
        {
            float dist = Vector3.Distance(objetoX.transform.position, transform.position);
            if (dist <= reachDist)
            {
                navMeshAgent.destination = objetoX.transform.position;
                if (!navMeshAgent.pathPending)
                {

                    CambioCoste y = x.GetComponent<CambioCoste>();
                    y.cambioCoste();
                    objetoX.SetActive(false);
                    navMeshAgent.destination = destination[i].position;
                    cogioObjeto = true;

                }
            }
        }
        // BUCLE DONDE LA IA VA CAMBIANDO SU DESTINO A UN NUEVO PATH
        // EN ESTE CASO EL MOVIMIENTO SERA RANDOM.
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            navMeshAgent.destination = destination[i].position;
            if (!navMeshAgent.pathPending)
            {
                 i = Random.Range(0, destination.Length);
               
            }
        }

    }

    // TRIGGERS DONDE BUSCA POR TAGS, EL DE SALTO PARA ANIMACIÓN,
    // OBJETO PARA ACIVAR EL OFFMESH Y HACER DESAPARECER EL CUBO
    // Y PUERTA PARA HACER DESAPARECER LAS PUERTAS CUANDO VAYA A PASAR.
    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "salto":

                anim.SetTrigger("Salto");
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
    // EN ESTE TRIGGER MIENTRAS ESTE EN ESTA CASILLA AUMENTARA SU VELOCIDAD.
    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "velocidad":
                navMeshAgent.speed = 8;
                break;
        }
    }
    // EN ESTE CUANDO SALGA DE LA CASILLA VOLVERA A SU VELOCIDAD NORMAL.
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "velocidad":
                navMeshAgent.speed = 4;
                break;
        }
    }




}
