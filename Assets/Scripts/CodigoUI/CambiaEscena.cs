using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscena : MonoBehaviour
{

    public GameObject funciones;         //Objeto donde ponemos la script

    public void cambiar()
    {
        SceneManager.LoadScene("Excena1");
        funciones.GetComponent<GuardarPersonaje>().Guardar();
    }
}
