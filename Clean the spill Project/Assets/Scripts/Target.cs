using System;
using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public Material oilMaterial;
    public Material cleanMaterial;
    public Material overCleanMaterial;

    public float health = 2f;
    public float damage = 0.01f;
    private float initialHealt;
    private bool isCleaned = false;
    private bool isOverCleaned = false;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        initialHealt = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("water")) return;

        health -= damage;

        if (health <= initialHealt && health > initialHealt / 2)
        {
            _renderer.material.Lerp(cleanMaterial, oilMaterial, health / initialHealt);

        }
        else if (health <= initialHealt / 2)
        {
            _renderer.material.Lerp(overCleanMaterial, cleanMaterial, health / initialHealt);

        }
                        
        if (health <= initialHealt / 1.5f && isCleaned == false){ 

            isCleaned = true;
            Scoreboard.scoreValue += 10;
            }
        if (health <= initialHealt / 3f && isOverCleaned == false)
        {

            isOverCleaned = true;
            Scoreboard.scoreValue -= 10;
        }


    }
}
