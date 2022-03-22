using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro_teleport : MonoBehaviour
{
void OnTriggerEnter(Collider gameObjectInformation)
 {
 if (gameObjectInformation.gameObject.name == "Character")
        {
            Debug.Log("entered collision");
            SceneManager.LoadScene(3);
        }
 }
}
