using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_colorFilter : MonoBehaviour
{
    public bool filter;
    public GameObject CG_Filter;
    
    // Start is called before the first frame update
    void Start()
    {
        filter = false;

        //gameObject.SetActive(false);

    }

    // Update is called once per frame
   void Update(){
       //cgFilter();
       if(Input.GetKeyDown("space")){
           FilterToggle();
           Debug.Log("Filter is toggled");
       }
       CG_Filter.SetActive(filter);

    }
    
    public void FilterToggle(){
        filter = !filter;
        if(filter == false){
            Debug.Log("filter is false");
        }
    }
    /*public void cgFilter(){
        //If statement der aktiverer filtret
        if(Input.GetKeyDown("space") && filter == true){

            CG_Filter.SetActive(false);
            if(CG_Filter == false){
            Debug.Log("Filter is false"); 
            }

            filterToggle();
            if(filter == false){
                 Debug.Log("Filter Boolean is false");
            }
            
        }else if (Input.GetKeyDown("space") && filter == false){

            CG_Filter.SetActive(true);
            Debug.Log("Filter is true");

            filterToggle();
            Debug.Log("Filter Boolean is true");
            
        }
    }*/
    
}
