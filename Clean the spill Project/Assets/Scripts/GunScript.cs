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
    public float chargeWaitInSeconds = 0.5f;
    public float deChargeWaitInSeconds = 0.5f;
    public GameObject bulletSpawn;
    private int chargeCopy;

    public AudioSource gunSound;

    public bool shooting;

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
        Rigidbody p = Instantiate(projectile, bulletSpawn.transform.position, fpsCamera.transform.rotation);
        p.velocity = -transform.forward * speed;
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