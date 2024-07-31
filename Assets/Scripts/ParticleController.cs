//using UnityEngine;

//public class ParticleController : MonoBehaviour
//{
//    public GameObject particlePrefab; // Prefab of the particle object
//    public int particleCount = 100; // Number of particles to spawn
//    public float particleSpeed = 2f; // Speed of particles
//    public float maxDistance = 5f; // Maximum distance from the center of the cube

//    private Transform cubeTransform; // Transform of the cube
//    private Collider cubeCollider; // Collider of the cube

//    private void Start()
//    {
//        cubeTransform = transform;
//        cubeCollider = GetComponent<Collider>();
//        SpawnParticles();
//    }

//    private void SpawnParticles()
//    {
//        for (int i = 0; i < particleCount; i++)
//        {
//            Vector3 randomPosition = cubeTransform.position + Random.insideUnitSphere * maxDistance;
//            GameObject particle = Instantiate(particlePrefab, randomPosition, Quaternion.identity);
//            particle.transform.SetParent(cubeTransform);
//            Rigidbody particleRigidbody = particle.GetComponent<Rigidbody>();
//            if (particleRigidbody != null)
//            {
//                particleRigidbody.velocity = Random.onUnitSphere * particleSpeed;
//            }
//        }
//    }

//    private void LateUpdate()
//    {
//        foreach (Transform child in cubeTransform)
//        {
//            Vector3 clampedPosition = child.position;
//            clampedPosition = cubeCollider.ClosestPoint(clampedPosition);
//            child.position = clampedPosition;
//        }
//    }


//}

using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab of the particle object
    public int particleCount = 100; // Number of particles to spawn
    public float maxSpeed = 2f; // Maximum speed of particles
    public float maxDistance = 5f; // Maximum distance from the center of the box

    private Transform boxTransform; // Transform of the box
    private float boxHalfSize; // Half the size of the box

    private void Start()
    {
        boxTransform = transform;
        boxHalfSize = GetComponent<Renderer>().bounds.extents.magnitude;
        SpawnParticles();
    }

    private void SpawnParticles()
    {
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 randomPosition = boxTransform.position + Random.insideUnitSphere * maxDistance;
            GameObject particle = Instantiate(particlePrefab, randomPosition, Quaternion.identity);
            particle.transform.SetParent(boxTransform);
            
            Rigidbody particleRigidbody = particle.GetComponent<Rigidbody>();
            if (particleRigidbody == null)
            {
                particleRigidbody = particle.AddComponent<Rigidbody>();
            }
            particleRigidbody.velocity = Random.onUnitSphere * Random.Range(0f, maxSpeed);
        }
        
    }
}
