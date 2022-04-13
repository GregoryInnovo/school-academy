using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{



    void OnTriggerEnter(Collider col)
    {
	Debug.Log("Hubo Colisión 1");
	if(col.gameObject.tag == "Boss"){
	   Debug.Log("Toque suelo");
	} else if (col.gameObject.tag == "Player"){
	   Debug.Log("Toque Player");
          
	}
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
