using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reapir : MonoBehaviour
{

    public Animator Anim;
    public float repairSpeed;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Anim.SetBool("Rep", true);
            GameObject.Find("Personaje1").GetComponent<ThirdPersonMov>().enabled = false;
            transform.Translate(Vector3.forward * repairSpeed * Time.deltaTime);
        }   
        else
        {
            Anim.SetBool("Rep", false);
            GameObject.Find("Personaje1").GetComponent<ThirdPersonMov>().enabled = true;
        }
    }
}
