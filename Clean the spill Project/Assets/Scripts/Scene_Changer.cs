using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 

public class Scene_Changer : MonoBehaviour
{

     public void ChangeScene(int index)
     {
         SceneManager.LoadScene(index);
     }
}
