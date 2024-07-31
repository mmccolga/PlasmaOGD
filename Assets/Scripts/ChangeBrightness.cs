using UnityEngine;

public class ChangeBrightness : MonoBehaviour
{
    [SerializeField] private Transform targetObject;  // The other cube
    [SerializeField] private Material objectMaterial;  // The material of the current cube
    [SerializeField] private float maxDistance = 5.0f; // Max distance where effect stops
    [SerializeField] private Color minEmissiveColor = Color.black; // Minimum brightness
    [SerializeField] private Color maxEmissiveColor = Color.white; // Maximum brightness

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetObject.position);
        Debug.Log(distance);
        UpdateBrightness(distance);
    }

    public void UpdateBrightness(float distance)
    {
        float lerpValue = Mathf.Clamp01(1 - (distance / maxDistance));
        Color currentEmissiveColor = Color.Lerp(minEmissiveColor, maxEmissiveColor, lerpValue);
        objectMaterial.SetColor("_EmissionColor", currentEmissiveColor);
    }
}
