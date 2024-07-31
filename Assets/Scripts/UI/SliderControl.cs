using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public GameObject[] objectsToControl;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Iterate through the objects and activate/deactivate them based on the slider value.
        foreach (GameObject obj in objectsToControl)
        {
            obj.SetActive(value > 0.5f); // You can adjust the threshold as needed.
        }
    }
}
