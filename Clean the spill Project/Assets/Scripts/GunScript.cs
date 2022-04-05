using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class GunScript : MonoBehaviour
{
    [Header("Projectile Prefabs")]
    public GameObject projectilePrefab;
    public GameObject ARProjectilePrefab;
    public GameObject oilProjectilePrefab;
    private Rigidbody projectile;
    private Rigidbody ARProjectile;
    private Rigidbody oilProjectile;
    [Header("Projectile Spray Settings")]
    [Tooltip("This changes how often a projectile is instantiated in sec.")]
    public float shootWaitTime = 0.1f;
    [Tooltip("How far does the projectile shoot")]
    public float range = 100f;
    [Tooltip("How fast are the projectile")]
    public float speed = 6;
    [Tooltip("How many projectiles can you shoot in one charge")]
    public int charge = 50; private int chargeCopy;
    private float chargeWaitInSeconds = 0.5f;
    private float deChargeWaitInSeconds = 0.5f;
    
    [Header("")]
    public Camera fpsCamera;
    [FormerlySerializedAs("bulletSpawn")] 
    public GameObject bulletSpawnTransform;
    [FormerlySerializedAs("gunSound")]
    public AudioSource spraySound;
    
    // Private variables
    [NonSerialized] public bool shooting;
    private bool canShoot = true;
    private int ammoType;

    private void Start()
    {
        projectile = projectilePrefab.GetComponentInChildren<Rigidbody>();
        oilProjectile = oilProjectilePrefab.GetComponentInChildren<Rigidbody>();
        ARProjectile = ARProjectilePrefab.GetComponentInChildren<Rigidbody>();

        chargeCopy = charge;
        
        InvokeRepeating(nameof(DeChargeGun), 0f, deChargeWaitInSeconds);
        InvokeRepeating(nameof(ChargeGun), 0f, chargeWaitInSeconds);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shooting = true;
            if (charge > 0)
            {
                if (!spraySound.isPlaying)
                    spraySound.Play();
                
                ShootObject();
            }
            else
            {
                if (spraySound.isPlaying)
                    spraySound.Pause();
            }
        }
        else
        {
            if (spraySound.isPlaying)
                spraySound.Pause();
            shooting = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Ammo is Standard");
            ammoType = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Ammo is Anti-Radiation");
            ammoType = 1;
        }
    }

    private void DeChargeGun()
    {
        if (!shooting) return;

        if (charge > 0)
            charge -= 1;
    }

    private void ChargeGun()
    {
        if (shooting) return;

        if (charge < chargeCopy)
            charge += 1;
    }

    private void ShootObject()
    {
        if (ammoType == 0 && canShoot)
        {
            ShootWater();
            canShoot = false;
            StartCoroutine(Wait(shootWaitTime));
        }
        else if (ammoType == 1 && canShoot)
        {
            ShootAR();
            canShoot = false;
            StartCoroutine(Wait(shootWaitTime));
        }
    }

    private void ShootWater()
    {
        Rigidbody p = Instantiate(projectile, bulletSpawnTransform.transform.position, fpsCamera.transform.rotation);
        p.velocity = -transform.forward * speed;
    }

    private void ShootAR()
    {
        Rigidbody p = Instantiate(ARProjectile, bulletSpawnTransform.transform.position, fpsCamera.transform.rotation);
        p.velocity = -transform.forward * speed;
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
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
                // target.TakeDamage(damage);
            }
        }
    }
}