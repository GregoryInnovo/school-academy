using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
   public static Timer sharedInstance;
   public bool timerActive = false;
   float CurrentTime;
   public int StarMinutes;
   public Text CurrentTimeText;

    
    void Awake() {
        // Make sure that only one exits
        if(sharedInstance == null) {    
            sharedInstance = this;
        }
    }

    void Start()
    {
       CurrentTime = StarMinutes;
    }
    void Update()
    {
        if (timerActive == true){
            CurrentTime = CurrentTime - Time.deltaTime;
            if (CurrentTime <= 0){
                timerActive = false;
                ManageScene.sharedInstance.gameOver = true;
                Start();
                Debug.Log("Se acabo el tiempo");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
         CurrentTimeText.text = time.Minutes.ToString()+ ":" + time.Seconds.ToString();   
    }

    public void StartTimer(){
        timerActive = true;
    }
    public void StopTimer(){
        timerActive = false;
    }
}
