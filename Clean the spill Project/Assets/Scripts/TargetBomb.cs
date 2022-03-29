using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetBomb : MonoBehaviour
{
    public GameObject oilSpillPreFab;
    private Rigidbody oilSpill;
    public int spillAmount = 10;
    public AudioManager audioManager;

    private void Start()
    {
        oilSpill = oilSpillPreFab.GetComponent<Rigidbody>();
    }
    
    private void RigidExplode()
    {
        for (int i = 0; i < spillAmount; i++)
        {
            var randomSpeed = Random.Range(1, 3);
            Rigidbody p = Instantiate(oilSpill, gameObject.transform.position, gameObject.transform.rotation);
            p.velocity = transform.forward * randomSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("water")) return;
        audioManager.PlayExplosionSound();
        RigidExplode();
        Destroy(gameObject);
    }
}