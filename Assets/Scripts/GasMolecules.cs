using UnityEngine;

public class GasMolecules : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        // Create a particle system.
        _particleSystem = GetComponent<ParticleSystem>();

        // Set the particle system's properties.
        _particleSystem.emissionRate = 100;
        _particleSystem.startSize = 0.1f;
        //_particleSystem.EndSize = 0.2f;
        

        // Start emitting particles.
        _particleSystem.Play();
    }
}
