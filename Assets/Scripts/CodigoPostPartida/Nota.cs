using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nota : MonoBehaviour
{
    public float nota;
    public Text timeText;
    public Text puntajeText;
    public Text scoreText;
    private float timeResult;
    // Start is called before the first frame update

    void Start()
    {
        
        puntajeText.text = PlayerPrefs.GetInt("puntaje").ToString();
        timeText.text = PlayerPrefs.GetFloat("tiempo").ToString();
        timeResult = int.Parse(PlayerPrefs.GetFloat("tiempo").ToString());
        if(timeResult >= 70)
        {
            nota = 5.0f;
            
        }else {
            nota = 3.0f;
        }
        scoreText.text = PlayerPrefs.GetFloat("tiempo").ToString();
        
    }
  
   



}
