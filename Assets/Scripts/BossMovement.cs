using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    [Header("Boss Speed")]
    public float speed = 0.5f;
    
    [Header("Boss Targets")]
    public List<GameObject> checkPoints = new List<GameObject>();
    public int randormIdx;
    public List<GameObject> currentCheckPoints = new List<GameObject>();

    [Header("Current Target")]
    public GameObject currentTarget;

    void Start()
    {
	GetCheckPoint();
    }
 
     void Update()
     {
	// Speed of the Boss
	float step = speed * Time.deltaTime;

	// Go to the target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);

	// Change the target
	if(transform.position == currentTarget.transform.position) {
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
}
