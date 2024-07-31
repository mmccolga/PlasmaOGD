using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideGUI : MonoBehaviour
{
    public GameObject Panel;
    int counter;
    
    public void hidePanel(){
        counter++;
        if (counter % 2 == 1 ){
            Panel.gameObject.SetActive(false);

        }
        else{
            Panel.gameObject.SetActive(true);
        }
    }

    

}

