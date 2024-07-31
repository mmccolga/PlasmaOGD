using UnityEngine;

public class ParticleController3 : MonoBehaviour
{
    public GameObject particlePrefab;
    public int particleCount = 100;
    public float vibrationFrequency = 5f;
    public float vibrationMagnitude = 0.1f;
    public float particleSpeed = 1f; // New variable for particle speed

    private Transform cubeTransform;
    private Vector3 cubeHalfSize;
    private GameObject[] particles;

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
            
            // Add particle velocity to the position
            particle.transform.position += vibrationOffset + particleSpeed * Time.deltaTime * particle.transform.forward;
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
