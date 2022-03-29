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
    public float oilDamage = 0.5f;
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
        // Water damage
        if (collision.gameObject.CompareTag("water"))
        {
            WaterDamage();
            Score();
        }
        else if (collision.gameObject.CompareTag("oil") || collision.gameObject.CompareTag("oilGun"))
        {
            OilDamage();
        }
    }

    private void WaterDamage()
    {
        if (health >= 0)
            health -= damage;

        if (health <= initialHealt && health > initialHealt / 2)
        {
            _renderer.material.Lerp(cleanMaterial, oilMaterial, health / initialHealt);
        }
        else if (health <= initialHealt / 2)
        {
            _renderer.material.Lerp(overCleanMaterial, cleanMaterial, health / initialHealt);
        }
    }

    private void OilDamage()
    {
        print("Hit with Oil!");

        if (health <= initialHealt)
        {
            health = initialHealt;
            _renderer.material = oilMaterial;
        }
    }

    private void Score()
    {
        if (health <= initialHealt / 1.5f && isCleaned == false)
        {
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