using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = 130f;

    public Camera fpsCamera;

    public GameObject prefab;
    public GameObject projectilePrefab;
    public GameObject oilProjectilePrefab;
    private Rigidbody projectile;
    private Rigidbody oilProjectile;
    public float speed = 12;
    public int charge = 200;
    public float chargeWaitInSeconds = 0.2f;
    public float deChargeWaitInSeconds = 0.5f;
    public GameObject bulletSpawn;
    private int chargeCopy;

    public AudioSource gunSound;

    public bool shooting;
    public float shootWaitTime = 0.1f;
    private bool canShoot = true;

    public int ammoType;

    private void Start()
    {
        projectile = projectilePrefab.GetComponentInChildren<Rigidbody>();
        oilProjectile = oilProjectilePrefab.GetComponentInChildren<Rigidbody>();

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
                if (!gunSound.isPlaying)
                    gunSound.Play();
                ShootObject();
            }
            else
            {
                if (gunSound.isPlaying)
                    gunSound.Pause();
            }
        }
        else
        {
            if (gunSound.isPlaying)
                gunSound.Pause();
            shooting = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Ammo is Standard");
            ammoType = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Ammo is Anti-Oil");
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
        else if (ammoType == 1)
        {
            Rigidbody p = Instantiate(oilProjectile, bulletSpawn.transform.position, fpsCamera.transform.rotation);
            p.velocity = -transform.forward * speed;
        }
    }

    private void ShootWater()
    {
        Rigidbody p = Instantiate(projectile, bulletSpawn.transform.position, fpsCamera.transform.rotation);
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