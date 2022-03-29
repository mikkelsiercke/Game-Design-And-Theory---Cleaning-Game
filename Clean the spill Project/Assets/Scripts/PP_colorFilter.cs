using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_colorFilter : MonoBehaviour
{
    public bool filter;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        filter = false;

    }

    // Update is called once per frame
   void Update(){

        //If statement der aktiverer filtret
        if(Input.GetKeyDown("space") && filter == true && gameObject == true){

            gameObject.SetActive(false);
            filter = false;
        }else if (Input.GetKeyDown("space") && filter == false && gameObject == false){

            gameObject.SetActive(true);
            filter = true;
        }
    }
}
