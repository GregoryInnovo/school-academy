using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPersonaje : MonoBehaviour
{
    public bool aj;
    public bool mujer;


    private void Awake()
    {
        aj = PlayerPrefs.GetInt("ajoSelect") == 1;
        mujer = PlayerPrefs.GetInt("mujerSelect") == 1;
    
    }

    private void Update()
    {
        if(aj == false && mujer == false)
        {
            aj = true;
        }
    }

    public void PersonajeChico()
    {
        aj = true;
        mujer = false;
        Guardar();
    }

    public void PersonajeChica()
    {
        aj = false;
        mujer = true;
        
        Guardar();
    }

   
    public void Guardar()
    {
        PlayerPrefs.SetInt("ajSelect", aj ? 1 : 0);
        PlayerPrefs.SetInt("mujerSelect", mujer ? 1 : 0);
    }
}
