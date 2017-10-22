using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTTemp : MonoBehaviour {

    public Transform[] path;

    public float speed = 5.0f;
    public float reachDist = 0.2f;
    public float tiempo = 5;
    public int i = 0;

    private bool fin = false;

    public Vector3 startPosition;

    void Start()
    {

        startPosition = this.transform.position;
        StartCoroutine(Temp());
    }

    IEnumerator Temp()
    {
        yield return new WaitForSeconds(tiempo);

        if (fin == false)
        {
            float dist = Vector3.Distance(path[i].position, transform.position);
            transform.position = Vector3.Lerp(transform.position, path[i].position, Time.deltaTime * speed);

            if (dist <= reachDist)
            {
                i = (i + 1) % path.Length;
            }
            if (i >= path.Length)
            {
                fin = true;
                tiempo = 5;
            }
        }

        yield return new WaitForSeconds(tiempo);

        if (fin == true)
        {
            float dist = Vector3.Distance(startPosition, transform.position);
            if (dist >= reachDist)
            {
                transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * speed);
                dist = Vector3.Distance(startPosition, transform.position);
                fin = false;
                tiempo = 5;
            }
            
        }
    }
}