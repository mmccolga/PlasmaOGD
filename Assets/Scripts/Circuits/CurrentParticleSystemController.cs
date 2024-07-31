using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Circuits
{
    public class CurrentParticleSystemController : MonoBehaviour
    {
        private ParticleSystem[] particleSystems;
        private bool playing;
        private float startSpeed;
        public float slowedSpeed;
        private float currentSpeed;

        private void Start()
        {
            particleSystems = GetComponentsInChildren<ParticleSystem>();
            startSpeed = particleSystems[0].main.simulationSpeed;
            currentSpeed = startSpeed;
            playing = false;
        }

        private void Update()
        {
            if (!playing)
                return;

            ScaleParticleSystemSpeedsWithAnimator();
        }

        private void ScaleParticleSystemSpeedsWithAnimator()
        {
            currentSpeed -= Time.deltaTime;
            if (currentSpeed < slowedSpeed)
                currentSpeed = slowedSpeed;

            foreach (ParticleSystem particleSystem in particleSystems)
            {
                var main = particleSystem.main;
                main.simulationSpeed = currentSpeed;
            }
        }

        public void PauseParticleSystems()
        {
            foreach (ParticleSystem particleSystem in particleSystems)
                particleSystem.Pause();

            playing = false;
        }

        public void PlayParticleSystems()
        {
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Play();
                var main = particleSystem.main;
                main.simulationSpeed = startSpeed;
            }

            playing = true;
            currentSpeed = startSpeed;
        }
    }
}
