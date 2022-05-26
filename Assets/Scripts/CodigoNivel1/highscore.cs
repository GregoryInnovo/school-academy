using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    public Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        // highscoreText.text = PlayerPrefs.GetFloat("tiempo").ToString();
        highscoreText.text = PlayerPrefs.GetInt("puntaje").ToString();
    }
}
