using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testingButtonsWithGOs : MonoBehaviour
{
    public Toggle Bin, ChargeNeg; //when the button is ON, B is into page and charge is negative
    //private bool BbuttonState, ChargeButtonState;
    //private int sign, rotationAngle;
    private bool tempB, tempCharge;
    Transform t1,t2;
    private int rotationAngle;
    Vector3 _initRotation;
    public bool isNextClicked;
    private int sign;

    //public bool isBottomCircle;
    public GameObject TopCircle, BottomCircle, PosChargeTop, NegChargeTop, PosChargeBottom, NegChargeBottom;
    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = 0;
        t1 = TopCircle.transform;
        t2 = BottomCircle.transform;
        _initRotation = t1.localEulerAngles; //get the rotation transform of the game object this script is attached to
        isNextClicked = false; // start out with the button not clicked
        TopCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle
        BottomCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle
        //rotationAngle = 10 * sign; //this increments the angle by +10 or -10
        tempB = Bin.isOn;
        tempCharge = ChargeNeg.isOn;
        //Bin.isOn = false;
        //ChargeNeg.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isNextClicked)
        {
            Debug.Log("isNext: " + isNextClicked);
            rotationAngle = rotationAngle + 10 * sign;
            if (rotationAngle <= -80 || rotationAngle >= 80)
            {
                rotationAngle = 0;
            }
            MoveCharge(TopCircle);
            MoveCharge(BottomCircle);
            

            //BottomCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
            
            //rotationAngle = rotationAngle + 10;
        }


        if (tempB != Bin.isOn || tempCharge != ChargeNeg.isOn)
        {
            MoveCharge(TopCircle);
            MoveCharge(BottomCircle);
            // Create an if statement to switch between the four Lorentz cases
            if (!Bin.isOn && !ChargeNeg.isOn)
            {
                BottomCircle.gameObject.SetActive(true);
                TopCircle.gameObject.SetActive(false);
                PosChargeBottom.SetActive(true);
                NegChargeBottom.SetActive(false);
                sign = 1;
                
                //if (isNextClicked)
                //{
                //    //BottomCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
                //    MoveCharge(BottomCircle);
                //}
            }
            else if (Bin.isOn && ChargeNeg.isOn)
            {
                BottomCircle.gameObject.SetActive(true);
                TopCircle.gameObject.SetActive(false);
                PosChargeBottom.SetActive(false);
                NegChargeBottom.SetActive(true);
                sign = 1;
                //if (isNextClicked)
                //{
                //    BottomCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
                //    //MoveCharge(BottomCircle);
                //}                   
            }
            else if (!Bin.isOn && ChargeNeg.isOn)
            {
                TopCircle.gameObject.SetActive(true);
                BottomCircle.gameObject.SetActive(false);
                PosChargeTop.SetActive(false);
                NegChargeTop.SetActive(true);
                sign = -1;
                //if (isNextClicked)
                //{
                //    TopCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
                //    //MoveCharge(TopCircle);
                //}
            }
            else if (Bin.isOn && !ChargeNeg.isOn)
            {
                TopCircle.gameObject.SetActive(true);
                BottomCircle.gameObject.SetActive(false);
                PosChargeTop.SetActive(true);
                NegChargeTop.SetActive(false);
                sign = -1;
                //if (isNextClicked)
                //{
                //    TopCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
                //    //MoveCharge(TopCircle);
                //}               
            }

            rotationAngle = 0;
            MoveCharge(TopCircle);
            MoveCharge(BottomCircle);
            tempB = Bin.isOn;
            tempCharge = ChargeNeg.isOn;
            //TopCircle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
        }

        
    }
    public void MoveCharge(GameObject circle)
    {
        circle.transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle
        isNextClicked = false;
        //rotationAngle = rotationAngle +10 * sign; //this increments the angle by +10 or -10
    }

    public void rotateMe()
    {
        isNextClicked = true;
        //Debug.Log("next was clicked");

    }
}
                    