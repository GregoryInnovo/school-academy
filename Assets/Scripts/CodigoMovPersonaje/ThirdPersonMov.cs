using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMov : MonoBehaviour
{
   public CharacterController controller;
   public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;


   void Update()
   {
       float Horizontal = Input.GetAxisRaw("Horizontal");
       float Vertical = Input.GetAxisRaw("Vertical");
       Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;  

       if(direction.magnitude >= 0.1f)
       {
           float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

           controller.Move(direction * speed * Time.deltaTime);
       }  
   }
}
