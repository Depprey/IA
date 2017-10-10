using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class david : MonoBehaviour {

    public float speed;
    public GameObject[] target;
    Vector3 inicio;
    bool fin = false;
    int i = 0;


	// Use this for initialization
	void Start () {

        inicio = this.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if(fin == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, target[i].transform.position, speed * Time.deltaTime);
            if (transform.position == target[i].transform.position)
            {
                i++;
            }
            if ( i == target.Length)
            {
                fin = true;
            }

        }else if (fin == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, inicio, speed * Time.deltaTime);
            if (transform.position == inicio)
                fin = false;
        }

	}
}
