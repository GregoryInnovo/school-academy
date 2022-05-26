using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{

    [Header("Boss Info")]
    public float speed = 0.5f;
    public bool canMove;
    public GameObject particlesBoss;
    public int currentRound;
    public Vector3 centerPosition;
    public bool isAttack;
    public bool canRepair;
    public SphereCollider bossCollider;
    
    [Header("Boss Targets")]
    public List<GameObject> checkPoints = new List<GameObject>();
    public int randomIdx;
    public List<GameObject> currentCheckPoints = new List<GameObject>();
    public int amountCheckPointsLeft;

    [Header("Current Target")]
    public GameObject currentTarget;

    [Header("Boss WaitTime")]
    public float waitTime = 1f;


     private float step;
    void Start()
    {
         GetCheckPoint();
         PlayerPrefs.SetFloat("tiempo", 0f);
         canMove = true;
         currentRound = 1;
         isAttack = true;
         centerPosition = new Vector3(-0.114f, 0.0306f, 0.328f);
    }
 
     void Update()
     {
          if(ManageScene.sharedInstance.gamePlay) {
               // Speed of the Boss
               step = speed * Time.deltaTime;


               if(canMove) {
                    // Go to the target
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget.transform.rotation, step);
               }

               if(!isAttack) {
                    // Go to the center
                    WaitInTheCenter();
               }


               // Change the target
               if(transform.position == currentTarget.transform.position) {
                    StartCoroutine(WaitDestroyPC());
                    GetCheckPoint();
               }
          }
     }

     void GetCheckPoint() {
          if(isAttack) {
               // Init with a random position
               if(checkPoints.Count > amountCheckPointsLeft) {
                    randomIdx = Random.Range(0, checkPoints.Count);
                    currentTarget = checkPoints[randomIdx];
                    currentCheckPoints.Add(currentTarget);
                    checkPoints.Remove(currentTarget);
                    particlesBoss.gameObject.SetActive(false);

               } else {
                    Debug.Log("El Boss termino de ir al punto");
                    isAttack = false;
               }
          }
     }

     IEnumerator WaitDestroyPC()
    {
        //Print the time of when the function is first called.
        canMove = false;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        canMove = true;
    }

    void WaitInTheCenter() {
         transform.position = Vector3.MoveTowards(transform.position, centerPosition, step);
         ManageScene.sharedInstance.isCounterActive = true;
         canMove = false;
         canRepair = true;
         particlesBoss.gameObject.SetActive(true);
    }

    void OnTriggerStay(Collider bossCollider) {
         if(Input.GetKeyDown(KeyCode.E) && canRepair) {
            if(bossCollider.gameObject.tag == "Player") {
               canMove = true;
               isAttack = true;
               canRepair = false;
               amountCheckPointsLeft = amountCheckPointsLeft - 7;
               ManageScene.sharedInstance.isCounterActive = false;
            }
            
         }

         if(Input.GetKeyDown(KeyCode.E) && !canRepair && amountCheckPointsLeft < 0) {
              PlayerPrefs.SetFloat("tiempo", Timer.sharedInstance.CurrentTime);
              SceneManager.LoadScene("Postpartida");
          }
         
    }
}
