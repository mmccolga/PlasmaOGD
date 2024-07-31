using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleWoutCheckBox : MonoBehaviour
{
    private Toggle toggle;
    public bool isBToggle;
    //public Color32 buttonColors1, buttonColors2;
    public string onLabel, offLabel;
    public GameObject onObject1, offObject1; //these are used for the magnetic field button.
    //because game objects have to be included for the charge button, nothing happens to those.
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(valueChanged);



    }

    // Update is called once per frame
    void Update()
    {
        //if(onObject1)
        //{
        //    transform.GetChild(0).gameObject.SetActive(true);
        //}
    }

    public void valueChanged(bool isOn)
    {

        string toggleLabel = onLabel;
        if (toggle.isOn)
        {
            toggleLabel = onLabel;
            if (isBToggle)
            {
                onObject1.SetActive(true);
                offObject1.SetActive(false);
            }
            else
            {
                onObject1.SetActive(false);
                offObject1.SetActive(true);
            }

        }
        else
        {
            toggleLabel = offLabel;
            if (isBToggle)
            {
                onObject1.SetActive(false);
                offObject1.SetActive(true);
            }
            else
            {
                onObject1.SetActive(true);
                offObject1.SetActive(false);
            }

        }

        toggle.GetComponentInChildren<Text>().text = toggleLabel;

    }


}




