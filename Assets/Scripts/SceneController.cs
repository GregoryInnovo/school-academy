using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

public static SceneController sharedInstance;

  void Awake() {
        // Make sure that only one exits
        if(sharedInstance == null) {    
            sharedInstance = this;
        }
    }

    public void SelectScene(int v) {
      
        switch (v) {
            case 0:
               
                StartCoroutine(FadeSalida("Menu_Principal"));
                Debug.Log("Escena Menú");         
                break;
            case 1:
                StartCoroutine(FadeSalida("SampleScene"));
                Debug.Log("Escena Game");
                break;
            case 2: 
                StartCoroutine(FadeSalida("Postpartida"));
		Debug.Log("Escena 2");
            break;
            case 3: 
                Debug.Log("Escena game");

            break;
            default: 
                Debug.Log("Escena Default");
            break;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    IEnumerator FadeSalida(string nombreScena)
    {    
        yield return new WaitForSeconds(3f);
        Debug.Log("Cambio escena");
	SceneManager.LoadScene(nombreScena);
    }

}
