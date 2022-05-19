using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Video de origen 

// https://www.youtube.com/watch?v=3qlRgICRoeA

public class LoadPErsonaje : MonoBehaviour
{
    public GameObject [] CharacterPrefabs;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = CharacterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

}
