using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelecterScene : MonoBehaviour
{

    public Button[] nivelBtn;

    // Start is called before the first frame update
    void Start()
    {
        int nivel = PlayerPrefs.GetInt("nivel",2);
        
        for(int i = 0; i < nivelBtn.Length; i++)
        {
            if(i+ 2> nivel)
            nivelBtn[i].interactable = false;
        }
    }


}
