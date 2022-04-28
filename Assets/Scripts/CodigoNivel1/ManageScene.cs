using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScene : MonoBehaviour
{
    [Header("Scene Information")]
    public static ManageScene sharedInstance;
    public bool isCounterActive;
    public bool gameOver;

    public Scrollbar Scrollbar1;
    private float lifeTime;
    public float speed = 0.08f;
    public Image healPC1;
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
        
        float Sb1V = Scrollbar1.value;

        if(!gameOver) {
            // Debug.Log("Gameplay is active");
            lifeTime += speed;
            Debug.Log(lifeTime);

            if(Sb1V >= 0.8) {
                healPC1.color = new Color(0, 255, 0);
            } 
            if(Sb1V <= 0.7 || Sb1V < 0.5) {
                healPC1.color = new Color(255, 232, 0);
            } 
            if(Sb1V <= 0.4) {
                healPC1.color = new Color(255, 0, 0);
            }

            // Activate the counter to fix the Boss
            if(isCounterActive) {
                Debug.Log("CounterActive");
            }
        } else {
            Debug.Log("GameOver");
        }
    }
}
