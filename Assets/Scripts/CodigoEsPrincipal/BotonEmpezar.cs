using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonEmpezar : MonoBehaviour
{
    public enum Leveles {PlayerSelecter = 0, NivelesSelecter = 1, Excena1 = 2, Excena2 = 3,Excena3 = 4, Excena4 = 5}
 
  public void CambiarNivel(Leveles level){
       SceneManager.LoadScene((int)level);
   }
   public void CambiarNivel(int indice){
       SceneManager.LoadScene(indice);
   }
}
