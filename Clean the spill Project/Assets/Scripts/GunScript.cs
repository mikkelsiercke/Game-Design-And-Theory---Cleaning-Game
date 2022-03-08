using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamera;
    
    public GameObject prefab;
    public Rigidbody projectile;
    public float speed = 6;
    public int charge = 50;
    private int chargeCopy;
    
    private void Start()
    {
        chargeCopy = charge;
    }

    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            print(charge);
            if (charge > 0)
            { 
                ShootObject();
                charge -= 1;
            }
        }
        else
        {
            if (charge < chargeCopy)
            {
                charge += 1;
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void ShootObject()
    {
        Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
        p.velocity = transform.forward * speed;
    }
}
