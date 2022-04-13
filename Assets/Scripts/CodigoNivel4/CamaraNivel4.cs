using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraNivel4 : MonoBehaviour
{

    public GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Jugador.transform.position;
    }
}
