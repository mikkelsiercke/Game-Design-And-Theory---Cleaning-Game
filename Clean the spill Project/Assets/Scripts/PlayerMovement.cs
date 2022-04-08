using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5.0f;
    public Camera fpsCamera;
    public GunScript gunScript;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        //Forward and sideways movement
        Vector3 move = transform.right * x + transform.forward * z;
        move *= moveSpeed;
            
        //Attach movement + controllable speed to specified controller in inspector
        // controller.Move(move * moveSpeed * Time.deltaTime);
        if (fpsCamera.transform.rotation.eulerAngles.x > 80 && fpsCamera.transform.rotation.eulerAngles.x <= 90)
        {
            if (gunScript.charge > 0 && gunScript.shooting)
            {
                move.y = jumpSpeed;
            }
        }
        
        move.y -= gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }

}
