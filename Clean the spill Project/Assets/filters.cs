using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filters : MonoBehaviour
{
    // Use this for initialization
 void Start () {
     
 }
 
 // Update is called once per frame
 void Update () {
     if (Input.GetKeyDown(KeyCode.Q))
     {
         gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
     }
     if (Input.GetKeyDown(KeyCode.E))
     {
         gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 0.4f);;
     }
     if (Input.GetKeyDown(KeyCode.R))
     {
         gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
     }
 }
}
