using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

public Material mat1;
public Material mat2;
public Material mat3;

void Start(){

}

void Update(){

if(Input.GetKeyDown(KeyCode.Alpha1))
{
gameObject.GetComponent<Renderer>().sharedMaterial = mat1;
}
 
if(Input.GetKeyDown(KeyCode.Alpha2))
{
gameObject.GetComponent<Renderer>().sharedMaterial = mat2;
}

if(Input.GetKeyDown(KeyCode.Alpha3))
{
gameObject.GetComponent<Renderer>().sharedMaterial = mat3;
}

}
}
