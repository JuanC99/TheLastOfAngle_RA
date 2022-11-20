using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticleController : MonoBehaviour
{
    private float currentVertical;
    private bool turboActivated;

    // Particle Running
    [SerializeField]
    private GameObject wheelParticleLeft;
    private ParticleSystem wheelParticleLeft_ps;

    [SerializeField]
    private GameObject wheelParticleRight;
    private ParticleSystem wheelParticleRight_ps;

    // Particles Running Turbo
    [SerializeField]
    private GameObject turboParticlesLeft;
    private ParticleSystem turboParticlesLeft_ps;

    [SerializeField]
    private GameObject turboParticlesRight;
    private ParticleSystem turboParticlesRight_ps;

    // Start is called before the first frame update
    void Start()
    {
        wheelParticleLeft_ps = wheelParticleLeft.GetComponent<ParticleSystem>();
        wheelParticleRight_ps = wheelParticleRight.GetComponent<ParticleSystem>();

        turboParticlesLeft_ps = turboParticlesLeft.GetComponent<ParticleSystem>();
        turboParticlesRight_ps = turboParticlesRight.GetComponent<ParticleSystem>();

        StopParticles();
    }

    private void StopParticles()
    {
        wheelParticleLeft_ps.Stop();
        wheelParticleRight_ps.Stop();

        turboParticlesLeft_ps.Stop();
        turboParticlesRight_ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        HandleWheelParticles();
        HandleTurboParticles();
    }

    private void HandleWheelParticles()
    {
        if (currentVertical > 0)
        {
            if (!wheelParticleLeft_ps.isPlaying){
                wheelParticleLeft_ps.Play();
                wheelParticleRight_ps.Play();
            }
        }
        else
        {
            if (wheelParticleLeft_ps.isPlaying){
                wheelParticleLeft_ps.Stop();
                wheelParticleRight_ps.Stop();
            }
        }
    }

    private void HandleTurboParticles()
    {
        if (turboActivated) { 
            if (!turboParticlesLeft_ps.isPlaying){
                turboParticlesLeft_ps.Play();
                turboParticlesRight_ps.Play();
            }
        }
        else { 
            if (turboParticlesLeft_ps.isPlaying){
                turboParticlesLeft_ps.Stop();
                turboParticlesRight_ps.Stop();
            }
        }
    }

    private void GetInputs()
    {
        currentVertical = PlayerInputs.VerticalInput;
        turboActivated = PlayerInputs.TurboActivated;
    }
}
