using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = 100f;

    public Camera fpsCamera;

    public GameObject prefab;
 public Rigidbody projectile;
    public Rigidbody oilProjectile;
    public float speed = 6;
    public int charge = 50;
    public float chargeWaitInSeconds = 0.5f;
    public float deChargeWaitInSeconds = 0.5f;
    public GameObject bulletSpawn;
    private int chargeCopy;

    public AudioSource gunSound;

    public bool shooting;

    public int ammoType;

    private void Start()
    {
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
        if (ammoType == 0)
        {
            Rigidbody p = Instantiate(projectile, bulletSpawn.transform.position, fpsCamera.transform.rotation);
            p.velocity = -transform.forward * speed;
        }
        else if (ammoType == 1)
        {
            Rigidbody p = Instantiate(oilProjectile, bulletSpawn.transform.position, fpsCamera.transform.rotation);
            p.velocity = -transform.forward * speed;
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
                // target.TakeDamage(damage);
            }
        }
    }
}