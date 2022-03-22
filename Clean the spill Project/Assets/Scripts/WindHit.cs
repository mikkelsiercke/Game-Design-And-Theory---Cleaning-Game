using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{
    public float windForce = 100f;
    public bool isLeft = true;
    public bool isRight = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            print("Hit!");
            var r = other.gameObject.GetComponent<Rigidbody>();
            if (isLeft)
            {
                r.AddForce(new Vector3(1, 0, 0) * windForce);
            } else if (isRight)
            {
                r.AddForce(new Vector3(-1, 0, 0) * windForce);
            }
        }
    }
}