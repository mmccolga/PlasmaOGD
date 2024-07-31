using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPositiveCurrentFadeEnd : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject pauseButton;

    public void SwitchButtons()
    {
        pauseButton.SetActive(false);
        resetButton.SetActive(true);
        GetComponent<Animator>().Play("Null State");
    }
}
