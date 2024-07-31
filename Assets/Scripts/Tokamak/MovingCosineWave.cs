using UnityEngine;

public class MovingCosineWave : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject parentObject; // Public parent GameObject
    public int numberOfPrefabs = 20;
    public float wavelength = 10f;
    public float frequency = 1f;
    public float numberOfWavelengths = 2f;
    public Material sphereMaterial; // Public Material variable for the prefab
    public float amplitude = 0.3f;
    public Vector3 sphereScale = new Vector3(0.05f, 0.05f, 0.05f);
    public float waveSpeed = 2f; // Public variable for controlling wave speed
    private float timeOffset; // Store the time offset

    void Start()
    {
        //GenerateCosineWave();
    }

    void Update()
    {
        // Update the time offset based on wave speed
        timeOffset += Time.deltaTime * waveSpeed;

        // Ensure that the time offset stays within one wavelength
        if (timeOffset > wavelength)
        {
            timeOffset -= 1.75f*wavelength;//1.75f for LF
        }
        GenerateCosineWave();

    }

    void GenerateCosineWave()
    {
        if (parentObject == null)
        {
            parentObject = new GameObject("CosineWave"); // Create a parent object if not assigned
        }

        float step = wavelength / numberOfPrefabs;
        float startX = transform.position.x;
        float startY = amplitude;
        float zOffset = transform.position.z;

        for (int i = 0; i < numberOfWavelengths * numberOfPrefabs; i++)
        {
            float x = startX + i * step - timeOffset; // Add time offset to x-coordinate
            float y = 0.55f + amplitude*Mathf.Cos(x * frequency);//this makes sure the wave is above the cube

            Vector3 position = new Vector3(x, y, zOffset);
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);

            // Set the material of the instantiated prefab
            Renderer renderer = sphere.GetComponent<Renderer>();
            if (renderer != null && sphereMaterial != null)
            {
                renderer.material = sphereMaterial;
            }
            sphere.transform.localScale = sphereScale;

            sphere.transform.parent = parentObject.transform; // Set the parent
            Destroy(sphere, 1f);

        }
        
    }
}
