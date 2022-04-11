using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Particles;

    void OnTriggerEnter(Collider col)
    {
	Debug.Log("Hubo Colisión 1");
	if(col.gameObject.tag == "Boss"){
	   Debug.Log("Generar Particulas");
           Particles.SetActive(true);
	} else if (col.gameObject.tag == "Player"){
	   Debug.Log("Detener Particulas");
           Particles.SetActive(false);
	}
        
    }

    void OnTriggerStay(Collider col)
    {
	//Debug.Log("Hubo Colisión 2");
        
    }

    void OnTriggerExit(Collider col)
    {
	Debug.Log("Hubo Colisión 3");
        
    }
}
