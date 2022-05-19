using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverReparar : MonoBehaviour
{

// Video de origen

//https://www.youtube.com/watch?v=qc0xU2Ph86Q

// VARIABLES 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
 
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity;
    [SerializeField] private LayerMask groundMask;



// REFERENCIAS

    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0,0,moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(isGrounded)
        {
             if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                 {
                   // Walk
                   Walk();

                  }
             else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                 {
                    //Run
                   Run();
                 }
             else if(moveDirection == Vector3.zero)
                 {
                 // Idle
                   Idle();

                  }

            moveDirection *= moveSpeed;
        }
      
        controller.Move(moveDirection * Time.deltaTime);

    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
         anim.SetFloat("Speed", 1);
    }
    
}