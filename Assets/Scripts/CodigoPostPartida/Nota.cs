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
    private int scoreResult;
    // Start is called before the first frame update

    void Start()
    {
        
        puntajeText.text = PlayerPrefs.GetInt("puntaje").ToString();
        timeText.text = PlayerPrefs.GetFloat("tiempo").ToString();
        scoreResult = int.Parse(PlayerPrefs.GetInt("puntaje").ToString());
        Debug.Log("puntaje es: " + scoreResult);
        timeResult = float.Parse(PlayerPrefs.GetFloat("tiempo").ToString());
        Debug.Log("tiempo es: " + timeResult);
        if(scoreResult >= 1400)
        {
            nota = 5.0f;      
        } else if(scoreResult <= 1399 && scoreResult >= 1000) {
            nota = 4.0f;
        } else if(scoreResult <= 999 && scoreResult >= 800) {
            nota = 3.0f;
        } else if(scoreResult <= 799 && scoreResult >= 300) {
            nota = 2.0f;
        } else {
            nota = 1.0f;
        }

        scoreText.text = nota.ToString();   
    }
}
