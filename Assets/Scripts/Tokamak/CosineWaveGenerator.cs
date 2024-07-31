using UnityEngine;

public class CosineWaveGenerator : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject parentObject; // Public parent GameObject
    public int numberOfPrefabs = 20;
    public float wavelength = 10f;
    public float frequency = 1f;
    public float numberOfWavelengths = 2f;
    public float amplitude = 0.3f;
    public Vector3 cosDataPtScale = new Vector3(.05f, .05f, .05f);
    public Material DataPtMaterial;
    public float speed = 1.0f;


    void Start()
    {
        GenerateCosineWave();
    }

    private void Update()
    {
        parentObject.transform.Translate(Vector3.right* -speed * Time.deltaTime);
    }

    void GenerateCosineWave()
    {
        if (parentObject == null)
        {
            parentObject = new GameObject("CosineWave"); // Create a parent object if not assigned
        }

        float step = wavelength / numberOfPrefabs;
        float startX = transform.position.x;// - (numberOfWavelengths * wavelength) / 2;
        float startY = amplitude;
        float zOffset = transform.position.z;

        for (int i = 0; i < numberOfWavelengths * numberOfPrefabs; i++)
        {
            float x = startX + i * step;
            float y = 0.5f+amplitude * Mathf.Cos(x * frequency); //this makes sure it's above the cube

            Vector3 position = new Vector3(x, y, zOffset);
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);

            // Set the material of the instantiated prefab
            Renderer renderer = sphere.GetComponent<Renderer>();
            if (renderer != null && DataPtMaterial != null)
            {
                renderer.material = DataPtMaterial;
            }
            sphere.transform.localScale = cosDataPtScale;

            sphere.transform.parent = parentObject.transform; // Set the parent
        }
    }
}
