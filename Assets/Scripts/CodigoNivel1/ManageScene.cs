using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    [Header("Scene Information")]
    public static ManageScene sharedInstance;
    public bool isCounterActive;
    public bool gameOver;

    void Awake() {
        // Make sure that only one exits
        if(sharedInstance == null) {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isCounterActive = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!gameOver) {

            // Activate the counter to fix the Boss
            if(isCounterActive) {
                Debug.Log("CounterActive");
            }
        } else {
            Debug.Log("GameOver");
        }
    }
}
