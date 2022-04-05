using System;
using UnityEngine;

public class TargetRadioactive : MonoBehaviour
{
    public float health = 2f;
    public float damage = 0.01f;

    [SerializeField] private PP_colorFilter _ppColorFilter;
    private ParticleSystem _particles;

    private bool _isCleaned;
    private bool scoreGain;

    private void Start()
    {
        _particles = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!_isCleaned)
        {
            if (_ppColorFilter.filter)
            {
                print("Is on");
                if (!_particles.isPlaying)
                    _particles.Play();
            }
            else
            {
                print("Is off");
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("AntiRadiation")) return;

        if (health >= 0 && !_isCleaned)
        {
            health -= damage;
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