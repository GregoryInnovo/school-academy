using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
  
  // Video de origen 


  // VARIABLES

    [SerializeField] private float mouseSens;

 // REFERENCES

    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        parent.Rotate(Vector3.up,mouseX);
    
    
    }


}
