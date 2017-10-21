using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerObjeto : MonoBehaviour {
    //Me lo he inventado un poco el start pero igual es algo así, llamar al componente OffMeshLink con el tag "SaltoBueno" y darle un nombre, para luego activarlo?
  /*void Start()
    {
        SaltoActivable = GameObject.FindGameObjectWithTag("SaltoBueno").GetComponent<OFfMeshLink>;
    }
    */

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Path16Objeto")
        {
            Destroy(col.gameObject);
            GameObject SaltoActivable = GameObject.FindGameObjectWithTag("SaltoBueno");
            SaltoActivable.SetActive(true);
        }
    }
}
