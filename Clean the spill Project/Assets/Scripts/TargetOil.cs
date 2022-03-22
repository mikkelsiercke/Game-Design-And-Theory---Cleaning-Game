using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOil : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("water") || collision.gameObject.CompareTag("target"))
        {
            Destroy(gameObject);
        }
        
    }
}
