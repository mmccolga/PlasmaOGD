using UnityEngine;

public class RotateThroughCoordinates : MonoBehaviour
{
    public Vector3[] rotationCoordinates;
    public float rotationSpeed = 30f;

    private int currentIndex = 0;

    void Update()
    {
        // Check if there are rotation coordinates defined
        if (rotationCoordinates.Length == 0)
        {
            Debug.LogWarning("No rotation coordinates defined.");
            return;
        }

        // Rotate towards the current target rotation
        Quaternion targetRotation = Quaternion.Euler(rotationCoordinates[currentIndex]);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the object has reached the current target rotation
        if (transform.rotation == targetRotation)
        {
            // Move to the next rotation coordinate
            currentIndex = (currentIndex + 1) % rotationCoordinates.Length;
        }
    }
}
