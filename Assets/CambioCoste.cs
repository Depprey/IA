using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CambioCoste : MonoBehaviour {
    
    public void cambioCoste()
    {
        Debug.Log("estas entrando al cambiocoste?? TAMBIEN!");
        NavMesh.SetAreaCost(6, 2f);
        StartCoroutine("restaurarCoste");
    }

    IEnumerator restaurarCoste()
    {
        yield return new WaitForSeconds(5);
        NavMesh.SetAreaCost(NavMesh.GetAreaFromName("PlataformaAreaMayor"), 10.0f);
        yield return null;
    }
}
