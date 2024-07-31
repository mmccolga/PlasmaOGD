using UnityEngine;

public class ParticleController2 : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab of the particle object
    public int particleCount = 100; // Number of particles to spawn
    public float vibrationFrequency = 5f; // Frequency of the vibration effect
    public float vibrationMagnitude = 0.1f; // Magnitude of the vibration effect

    private Transform cubeTransform; // Transform of the cube
    private Vector3 cubeHalfSize; // Half the size of the cube
    private GameObject[] particles; // Array to store the instantiated particles

    private void Start()
    {
        cubeTransform = transform;
        Renderer cubeRenderer = GetComponent<Renderer>();
        cubeHalfSize = cubeRenderer.bounds.extents;
        particles = new GameObject[particleCount];
        SpawnParticles();
        
    }

    private void SpawnParticles()
    {
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 randomPosition = cubeTransform.position + RandomVectorWithinBox();
            GameObject particle = Instantiate(particlePrefab, randomPosition, Quaternion.identity);
            
            particles[i] = particle;
            

        }

    }

    private Vector3 RandomVectorWithinBox()
    {
        float x = Random.Range(-cubeHalfSize.x, cubeHalfSize.x);
        float y = Random.Range(-cubeHalfSize.y, cubeHalfSize.y);
        float z = Random.Range(-cubeHalfSize.z, cubeHalfSize.z);
        return new Vector3(x, y, z);
    }

    private void Update()
    {
        for (int i = 0; i < particleCount; i++)
        {
            GameObject particle = particles[i];
            Vector3 vibrationOffset = GetVibrationOffset(i);
            particle.transform.position = cubeTransform.position + vibrationOffset;
            
        }
    }

    private Vector3 GetVibrationOffset(int index)
    {
        float time = Time.time * vibrationFrequency + index;
        float x = Mathf.PerlinNoise(time, 0f) * 2f - 1f;
        float y = Mathf.PerlinNoise(0f, time) * 2f - 1f;
        float z = Mathf.PerlinNoise(time, time) * 2f - 1f;
        return new Vector3(x, y, z) * vibrationMagnitude;
    }

    
}
