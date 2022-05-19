using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Video de origen

// https://www.youtube.com/watch?v=3qlRgICRoeA

public class CharacterSelection : MonoBehaviour
{

    public GameObject[] personajes;

    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        personajes[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % personajes.Length;
        personajes[selectedCharacter].SetActive(true);
    }
 
    public void PreviousCharacter()
    {
        personajes[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter<0)
        {
            selectedCharacter += personajes.Length;       
        }
        personajes[selectedCharacter].SetActive(true);
    }

   public void StartGame()
   {
       PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
       SceneManager.LoadScene(2, LoadSceneMode.Single);
   }
}
