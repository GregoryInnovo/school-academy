using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    [Header("Boss Info")]
    public float speed = 0.5f;
    public bool canMove;
    
    [Header("Boss Targets")]
    public List<GameObject> checkPoints = new List<GameObject>();
    public int randormIdx;
    public List<GameObject> currentCheckPoints = new List<GameObject>();

    [Header("Current Target")]
    public GameObject currentTarget;

     [Header("Boss WaitTime")]
    public float waitTime = 1f;

    void Start()
    {
         GetCheckPoint();
         canMove = true;
    }
 
     void Update()
     {
          // Speed of the Boss
	     float step = speed * Time.deltaTime;


          if(canMove) {
               // Go to the target
               transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);
               //transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget.transform.rotation, step);
          }

          // Change the target
          if(transform.position == currentTarget.transform.position) {
               StartCoroutine(WaitDestroyPC());
               GetCheckPoint();
          } 
     }

     void GetCheckPoint() {
	// Init with a random position
          randormIdx = Random.Range(0, checkPoints.Count);
          currentTarget = checkPoints[randormIdx];
          currentCheckPoints.Add(currentTarget);
          checkPoints.Remove(currentTarget);
     }

     IEnumerator WaitDestroyPC()
    {
        //Print the time of when the function is first called.
        canMove = false;
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        canMove = true;
    }
}
