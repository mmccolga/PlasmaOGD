using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minRotationSpeed = 10f;
    public float maxRotationSpeed = 50f;

    private Vector3 rotationSpeed;

    void Start()
    {
        // Generate random rotation speed values for each axis
        float xSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        float ySpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        float zSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        rotationSpeed = new Vector3(xSpeed, ySpeed, zSpeed);
    }

    void Update()
    {
        // Rotate the object based on the random rotation speed
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
