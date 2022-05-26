using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public CharacterController controller;
    public float velocidadMovimiento = 4.0f;
    public float VelocidadRotacion = 250.0f;
    private Animator anim;
    public float x, y;

    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * VelocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);


        // Parte del sonido
        if(Input.GetButtonDown("Horizontal"))
        {
            Hactivo = true;
            pasos.Play();
        }
        if(Input.GetButtonDown("Vertical"))
        {
            Vactivo = true;
            pasos.Play();
        }

        //pause
        if(Input.GetButtonDown("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
            }
        }
    }
}
