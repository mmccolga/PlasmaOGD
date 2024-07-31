using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTicksScript : MonoBehaviour
{
    //Taken from:https://gamedev.stackexchange.com/questions/195546/how-to-make-a-unity-slider-sit-over-evenly-spaced-points
    //offset in pixel
    public float offset = 200f;
    public int ticks = 3;
    //your cicle icon
    public GameObject tick;
    public int tickPosition = 0;
    //this is the fillArea of the slider
    public Transform dotParent;

    void Start()
    {
        float totalWidth = GetComponent<RectTransform>().rect.width;
        float offSetAmount = offset / totalWidth;
        float anchorDistance = (1f - 2 * offSetAmount) / (ticks - 1);
        for (int index = 0; index < ticks; index++)
        {
            GameObject spawnTick = Instantiate(tick, dotParent);
            spawnTick.GetComponent<RectTransform>().anchorMin = new Vector2(anchorDistance * index + offSetAmount, 0);
            spawnTick.GetComponent<RectTransform>().anchorMax = new Vector2(anchorDistance * index + offSetAmount, 0);
        }
        SetSpinner(tickPosition);
    }

    public void SetSpinner(int index)
    {
        float totalWidth = GetComponent<RectTransform>().rect.width;
        float maxValue = GetComponent<Slider>().maxValue;
        float offSetAmount = maxValue * offset / totalWidth;
        float lengthBetweenTicks = (maxValue - offSetAmount * 2) / (ticks - 1);
        GetComponent<Slider>().value = tickPosition; // index * lengthBetweenTicks + offSetAmount;
        Debug.Log("Slider value: " + GetComponent<Slider>().value);
    }

}
