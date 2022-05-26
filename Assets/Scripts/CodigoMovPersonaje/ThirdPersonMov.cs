using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMov : MonoBehaviour
{
   public CharacterController controller;
   public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float VelocidadRotacion = 250.0f;

    public Animator Anim;
    float turnSmoothVel;

    public float UpSpeed;
    public float DownSpeed;

    void Update()
   {
       float Horizontal = Input.GetAxisRaw("Horizontal");
       float Vertical = Input.GetAxisRaw("Vertical");

       Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
       {
           //float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
           //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

           controller.Move(-direction * speed * Time.deltaTime);
       }

        // New Parts of code 
        //transform.Rotate(0, Horizontal * Time.deltaTime * VelocidadRotacion, 0);

        //Anim.SetFloat("VelX", Horizontal);
        //Anim.SetFloat("VelY", Vertical);

        // Para los movimientos 
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            Anim.SetBool("Run", true);
        } else if (Input.GetKey(KeyCode.S))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Anim.SetBool("Run", true);
        } else if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Anim.SetBool("Run", true);
        } else if (Input.GetKey(KeyCode.W))
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Anim.SetBool("Run", true);
        } else
        {
            Anim.SetBool("Run", false);
        }
    }




}
