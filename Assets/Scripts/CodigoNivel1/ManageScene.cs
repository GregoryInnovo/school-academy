using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    [Header("Scene Information")]
    public static ManageScene sharedInstance;
    public bool isCounterActive;
    public GameObject gameplayUI,gameOverUI, dialogUI;
    public bool gamePlay;
    public bool gameOver;
    public bool dialog;
    public int deadPCs;
    public int currentRound;
    public bool aux;

    void Awake() {
        // Make sure that only one exits
        if(sharedInstance == null) {    
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        deadPCs = 0;
        currentRound = 1;
        dialog = true;
        gameOver = false;
        gamePlay = false;
        isCounterActive = false;
        dialogUI.SetActive(true);
        aux = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!gameOver) {
          if(deadPCs == 3) {
            gameOver = true;
          }

          if(isCounterActive) {
              // Debug.Log("CounterActive");
              Timer.sharedInstance.timerActive = true;
          }
        } else {
            // Debug.Log("GameOver");
            gameplayUI.SetActive(false);
            gameOverUI.SetActive(true);
            
            if(aux){
                 StartCoroutine(FadeSalida());
                aux=false;
             } 
             
           
        }
    }

    public void StartGame() {
        gamePlay = true;
        dialogUI.SetActive(false);
        gameplayUI.SetActive(true);
    }

    IEnumerator FadeSalida()
    {    
        yield return new WaitForSeconds(3f);
        Debug.Log("Cambio escena");
	    SceneManager.LoadScene("Postpartida");
    }

}
