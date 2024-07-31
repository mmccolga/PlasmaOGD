using UnityEngine;
using UnityEngine.UI;

public class GameObjectSlider : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToTransition;

    public Slider slider;

    private int currentIndex = 0;

    private void Start()
    {
        // Set initial object and slider value
        SetActiveObject(currentIndex);
        slider.value = currentIndex;
    }

    public void OnSliderValueChanged()
    {
        int newIndex = Mathf.RoundToInt(slider.value);

        if (newIndex != currentIndex)
        {
            SetActiveObject(newIndex);
            currentIndex = newIndex;
        }
    }

    private void SetActiveObject(int index)
    {
        for (int i = 0; i < objectsToTransition.Length; i++)
        {
            objectsToTransition[i].SetActive(i == index);
        }
    }
}
