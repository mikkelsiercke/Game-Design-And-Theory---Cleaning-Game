using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Material oilMaterial;
    public Material cleanMaterial;
    public Material overCleanMaterial;

    public float health = 2f;
    public float damage = 0.01f;
    private float initialHealt;

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
    }
}
