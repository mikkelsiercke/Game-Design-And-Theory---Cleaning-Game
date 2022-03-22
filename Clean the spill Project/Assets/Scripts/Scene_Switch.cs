using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Switch : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
