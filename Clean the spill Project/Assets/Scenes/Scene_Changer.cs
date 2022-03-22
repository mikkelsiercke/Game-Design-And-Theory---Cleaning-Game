using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 

public class Scene_Changer : MonoBehaviour
{
    public void Scene1() {  
        SceneManager.LoadScene(0);  
    }  
    public void Intro() {  
        SceneManager.LoadScene(1);  
    }  
    public void Level1() {  
        SceneManager.LoadScene(2);  
    } 
     public void Level2() {  
        SceneManager.LoadScene(3);  
    }

     public void ChangeScene(int index)
     {
         SceneManager.LoadScene(index);
     }
}
