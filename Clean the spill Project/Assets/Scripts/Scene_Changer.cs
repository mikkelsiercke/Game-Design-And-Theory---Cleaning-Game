using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 

public class Scene_Changer : MonoBehaviour
{
    public void Scene1() {  
        SceneManager.LoadScene(0);  
    }  
    public void Scene2() {  
        SceneManager.LoadScene(1);  
    }  
    public void Scene3() {  
        SceneManager.LoadScene(2);  
    } 
     public void Scene4() {  
        SceneManager.LoadScene(3);  
    } 
}
