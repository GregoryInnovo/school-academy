using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnMainMenu());
    }

    IEnumerator ReturnMainMenu()
    {    
        yield return new WaitForSeconds(13f);
        SceneManager.LoadScene("Prin");
    }
}
