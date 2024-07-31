using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhaseSwitcher : MonoBehaviour
{
    public GameObject[] objectsToSwitch; // Array to hold the game objects to switch between.
    public Canvas newCanvas;
    public TextMeshProUGUI solidLabel;
    public TextMeshProUGUI liquidLabel;
    public TextMeshProUGUI gasLabel;
    public TextMeshProUGUI plasmaLabel;
    public GameObject capacitor;
    public Toggle eFieldToggle;
    public Slider slider; // Reference to the slider component.

    private int currentIndex = 0;

    private void Start()
    {
        
        //need to set these all to off because they need to all be on to
        //solidLabel.enabled = false;
        liquidLabel.enabled = false;
        gasLabel.enabled = false;
        plasmaLabel.enabled = false;
        slider.onValueChanged.AddListener(OnSliderValueChanged);

    }

    private void OnSliderValueChanged(float value)
    {
        currentIndex = Mathf.RoundToInt(value);
        SwitchObjects(currentIndex);
        TurnOnEfieldButton(currentIndex);
        TurnOnPhaseLabel(currentIndex);
    }

    private void SwitchObjects(int index)
    {
        for (int i = 0; i < objectsToSwitch.Length; i++)
        {
            if (i == index)
            {
                objectsToSwitch[i].SetActive(true);
                
            }
            else
            {
                objectsToSwitch[i].SetActive(false);
                
            }
        }
    }

    private void TurnOnEfieldButton(int index)
    {
        if (index == 3)
            eFieldToggle.gameObject.SetActive(true);
        else
        {
            eFieldToggle.gameObject.SetActive(false);
            capacitor.SetActive(false);
        }
    }

    private void TurnOnPhaseLabel(int index)
    {
        if (index == 0)
        {
            solidLabel.enabled = true;
            liquidLabel.enabled = false;
            gasLabel.enabled = false;
            plasmaLabel.enabled = false;
        }
        else if (index == 1)
        {
            solidLabel.enabled = false;
            liquidLabel.enabled = true;
            gasLabel.enabled = false;
            plasmaLabel.enabled = false;
        }
        else if (index == 2)
        {
            solidLabel.enabled = false;
            liquidLabel.enabled = false;
            gasLabel.enabled = true;
            plasmaLabel.enabled = false;
        }
        else
        {
            solidLabel.enabled = false;
            liquidLabel.enabled = false;
            gasLabel.enabled = false;
            plasmaLabel.enabled = true;
        }
    }
}
