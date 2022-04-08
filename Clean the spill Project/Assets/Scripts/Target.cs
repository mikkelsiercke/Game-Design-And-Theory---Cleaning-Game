using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Materials")]
    public Material oilMaterial;
    public Material cleanMaterial;
    public Material overCleanMaterial;

    [Header("")]
    public float health = 100f;

    [Header("Required references")] 
    public GameObject character;
    
    private float _damage;
    private float _initialHealth;
    private bool _isCleaned = false;
    private bool _isOverCleaned = false;
    private Renderer[] _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponentsInChildren<Renderer>();
        _damage = character.GetComponentInChildren<GunScript>().damage;
        
        _initialHealth = health;

        foreach (var rend in _renderer)
        {
            rend.material = oilMaterial;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Water damage
        if (collision.gameObject.CompareTag("water"))
        {
            WaterDamage();
            Score();
        }
        // Oil damage
        else if (collision.gameObject.CompareTag("oil") || collision.gameObject.CompareTag("oilGun"))
        {
            OilDamage();
        }
    }

    private void WaterDamage()
    {
        if (health >= 0)
            health -= _damage;

        if (health <= _initialHealth && health > _initialHealth / 2)
        {
            foreach (var rend in _renderer)
            {
                rend.material.Lerp(cleanMaterial, oilMaterial, health / _initialHealth);
            }
        }
        else if (health < _initialHealth / 2)
        {
            foreach (var rend in _renderer)
            {
                rend.material.Lerp(overCleanMaterial, cleanMaterial, health / _initialHealth);
            }
        }
    }

    private void OilDamage()
    {
        print("Hit with Oil!");

        if (health <= _initialHealth)
        {
            health = _initialHealth;
            
            foreach (var rend in _renderer)
            {
                rend.material = oilMaterial;
            }
        }
    }

    private void Score()
    {
        if (health <= _initialHealth / 1.5f && _isCleaned == false)
        {
            _isCleaned = true;
            Scoreboard.scoreValue += 10;
        }

        if (health <= _initialHealth / 3f && _isOverCleaned == false)
        {
            _isOverCleaned = true;
            Scoreboard.scoreValue -= 10;
        }
    }
}