using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARStaticVarChanger : MonoBehaviour
{
    public Button StartARButton;
    public GameObject ARWarningImage;
   
    // Update is called once per frame
    public void ShowARWarning()
    {
        print("Start wasWarned = " + ARStaticVarHolder.wasWarned);
        if (ARStaticVarHolder.wasWarned == false)
        {
            ARWarningImage.SetActive(true);
            //ARWarningImage.GetComponent<Image>().enabled = true;
            ARStaticVarHolder.wasWarned = true;
            print("wasWarned = "+ARStaticVarHolder.wasWarned);
            print("ARImage = " + ARWarningImage.activeSelf);
        }
        else
        {
            ARWarningImage.SetActive(false);
            print("ARImage = " + ARWarningImage.activeSelf);
        }
        print("End wasWarned = " + ARStaticVarHolder.wasWarned);
        

    }
}
