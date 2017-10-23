using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour {

    public GameObject puertaAbrir;
	// Use this for initialization
	public void abrirPuerta()
    {
        puertaAbrir.SetActive(false);
        StartCoroutine("cerrarPuerta");
    }
    IEnumerator cerrarPuerta()
    {
        yield return new WaitForSeconds(5);
        puertaAbrir.SetActive(true);
        yield return null;
    }
}
