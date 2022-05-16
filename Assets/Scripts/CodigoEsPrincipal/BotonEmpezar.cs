using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonEmpezar : MonoBehaviour
{
 
public void LoadScene(string nombreEscena){

    SceneManager.LoadScene(nombreEscena);

}


}