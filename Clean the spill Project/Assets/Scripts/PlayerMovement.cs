using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5.0f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        //Forward and sideways movement
        Vector3 move = transform.right * x + transform.forward * z;

        //Attach movement + controllable speed to specified controller in inspector
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

}
