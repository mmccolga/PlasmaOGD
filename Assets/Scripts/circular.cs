using UnityEngine;
using UnityEngine.UI;

public class circular : MonoBehaviour
{
    public GameObject bigR;
    public GameObject smallR;
    public GameObject LorentzBigR;
    public GameObject LorentzSmallR;
    //public Toggle myToggle;
    public float speed = 720f;
    //public Vector3 _initRot;

    public void Start()
    {
        //_initRot = transform.lo calEulerAngles;
        //myToggle = GetComponent<UnityEngine.UI.Toggle>();
        //myToggle.onValueChanged.AddListener(valueChanged);
    }
    
    private void Update()
    {
        // Rotate around the target object.
        if ( bigR.activeSelf)
        {
            Debug.Log( " bigR active: " + bigR.activeSelf);
            LorentzBigR.SetActive(false);
            LorentzSmallR.SetActive(true);

            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }

        else
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0);
            LorentzBigR.SetActive(true);
            LorentzSmallR.SetActive(false);
        }
    }

    //public void valueChanged(bool isOn)
    //{

    //    //string myToggleLabel = onLabel;
    //    if (myToggle.isOn)
    //    {
    //        //toggleLabel = onLabel;
            
    //        bigR.transform.Rotate(0, -speed * Time.deltaTime, 0);
            
    //    }
    //    else
    //    {
          
    //        smallR.transform.Rotate(0, -speed * Time.deltaTime, 0);
    //    }

    //}
       
}
