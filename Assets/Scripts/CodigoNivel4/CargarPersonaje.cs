using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject ajpersonaje;
    public GameObject mujerpersonaje;


    public bool aj;
    public bool mujer;

    private void Update()
    {
        aj = PlayerPrefs.GetInt("ajSelect") == 1;
        mujer = PlayerPrefs.GetInt("mujerSelect") == 1;
    

        if(aj == true)
        {
            ajpersonaje.SetActive(true);
            Destroy(mujerpersonaje);
    
        }

        if (mujer == true)
        {
            mujerpersonaje.SetActive(true);
            Destroy(ajpersonaje);
        }

    }
}
