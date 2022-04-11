using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayers : MonoBehaviour
{   
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    //
    private float movimientosH;
    private float movimientosV;
    //
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
      movimientosH = Input.GetAxis("Horizontal");
      movimientosV = Input.GetAxis("Vertical");

      transform.Rotate(0, movimientosH * Time.deltaTime * rotationSpeed, 0);
      transform.Translate(0, 0, movimientosV * Time.deltaTime * runSpeed);

      //animator.SetFloat("VelX", movimientosH);
      //animator.SetFloat("VelY", movimientosV);

      
      if (Mathf.Abs(movimientosV) > 0) {
        animator.SetBool("isRunning", true);
      } else {
        animator.SetBool("isRunning", false);
      }
    }
}
