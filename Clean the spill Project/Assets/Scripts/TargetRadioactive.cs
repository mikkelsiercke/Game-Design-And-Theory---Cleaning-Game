using System;
using UnityEngine;

public class TargetRadioactive : MonoBehaviour
{
    public float health = 100f;
    public GameObject character;
    public GameObject particlePrefab;

    private PP_colorFilter _ppColorFilter;
    private ParticleSystem _particles;

    private float _damage;
    private bool _isCleaned;
    private bool scoreGain;

    private void Start()
    {
        particlePrefab = Instantiate(particlePrefab, gameObject.transform);
        _particles = particlePrefab.GetComponent<ParticleSystem>();
        _damage = character.GetComponentInChildren<GunScript>().damage;
        _ppColorFilter = GameObject.FindWithTag("Player").GetComponentInChildren<PP_colorFilter>();
    }

    private void Update()
    {
        if (!_isCleaned)
        {
            if (_ppColorFilter.filter)
            {
                print(_ppColorFilter.filter);
                if (!_particles.isPlaying)
                    _particles.Play();
            }
            else
            {
                print(_ppColorFilter.filter);
                if (_particles.isPlaying)
                {
                    _particles.Clear();
                    _particles.Stop();
                }
            }
        }
        else
        {
            _particles.Clear();
            _particles.Stop();
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("AntiRadiation")) return;

        if (health >= 0 && !_isCleaned)
        {
            health -= _damage;
        }
        else
        {
            _isCleaned = true;
            if (!scoreGain)
            {
                Scoreboard.scoreValue += 10;
                scoreGain = true;
            }
        }
    }
}