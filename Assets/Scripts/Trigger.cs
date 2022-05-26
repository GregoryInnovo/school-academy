using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public GameObject Particles;
    public Image healPC;
    public Scrollbar Scrollbar;

    private float lifeTime;
    public float speed = 0.05f;
    public bool reduceLife;
    private bool aux = true;

    public static Trigger sharedInstance;

        
    void Awake() {
        // Make sure that only one exits
        if(sharedInstance == null) {    
            sharedInstance = this;
        }
    }

    void Update() {
        if(reduceLife) {
        lifeTime = speed * Time.deltaTime;
        
        float SbV = Scrollbar.value;
        Scrollbar.value = Scrollbar.value - lifeTime;

        if(SbV >= 0.8) {
                healPC.color = new Color(0, 255, 0);
            } 
            if(SbV <= 0.7 || SbV < 0.5) {
                healPC.color = new Color(255, 232, 0);
            } 
            if(SbV <= 0.4 | SbV < 0.1) {
                healPC.color = new Color(255, 0, 0);
            }
            if(SbV <= 0.0) {
                healPC.color = new Color(0, 0, 0);
                if(aux) {
                    ManageScene.sharedInstance.deadPCs = ManageScene.sharedInstance.deadPCs + 1;
                    ManageScene.sharedInstance.reduceHighScore();
                    aux = false;
                }
            }
        }
        

    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log("Hubo Colisión 1");
        if(col.gameObject.tag == "Boss"){
            Debug.Log("Generar Particulas");
            Particles.SetActive(true);
            reduceLife = true;
        } else if (col.gameObject.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Detener Particulas");
                StartCoroutine(stopParticlesSystem());
                
                reduceLife = false;
                ManageScene.sharedInstance.incrementHighScore();
            }
        }          
    }

       
    

    IEnumerator stopParticlesSystem()
    {    
        yield return new WaitForSeconds(4f);
        Particles.SetActive(false);
    }
}
