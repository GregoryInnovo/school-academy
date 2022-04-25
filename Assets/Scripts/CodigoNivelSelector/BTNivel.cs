using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNivel : MonoBehaviour
{
   public void Escenas(string nombreEscena)
   {
       SceneManager.LoadScene("nombreEscena");
   }
}
