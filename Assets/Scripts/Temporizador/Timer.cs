using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
   float CurrentTime;
   public int StarMinutes;
   public Text CurrentTimeText;
    // Update is called once per frame
    void Start()
    {
       CurrentTime = StarMinutes * 60;
    }
    void Update()
    {
        if (timerActive == true){
            CurrentTime = CurrentTime - Time.deltaTime;
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
