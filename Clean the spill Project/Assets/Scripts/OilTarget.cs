using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("water")) return;
        
        Destroy(gameObject);
    }
}
