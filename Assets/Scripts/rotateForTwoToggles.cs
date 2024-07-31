using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateForTwoToggles : MonoBehaviour
{
    public Toggle Bin,ChargeNeg; //when the button is ON, B is into page and charge is negative
    private bool BbuttonState, ChargeButtonState;
    private int sign, rotationAngle;
    private bool tempB, tempCharge;
    Transform t;
    Vector3 _initRotation;
    private bool isNextClicked;

    public bool isBottomCircle;
    public GameObject   PosCharge, NegCharge;
    // Start is called before the first frame update
    void Start()
    {
         if (isBottomCircle)
        {
            this.gameObject.SetActive(true);
            PosCharge.SetActive(true);
            NegCharge.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
            PosCharge.SetActive(false);
            NegCharge.SetActive(false);
        }
        //these will detect a change in the toggle buttons
        tempB = false;
        tempCharge = false;

        rotationAngle = 0;
        t = transform;
        _initRotation = t.localEulerAngles; //get the rotation transform of the game object this script is attached to
        isNextClicked = false; // start out with the button not clicked
        transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle
        rotationAngle = 10 * sign; //this increments the angle by +10 or -10

        BbuttonState = Bin.isOn;
        ChargeButtonState = ChargeNeg.isOn;

    }

   

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
        if (tempB != BbuttonState || tempCharge != ChargeButtonState)
        {
            rotationAngle = 0;
            
            // Create an if statement to switch between the four Lorentz cases
            if (isBottomCircle)
            {
                this.gameObject.SetActive(true);
                if (!Bin.isOn && !ChargeNeg.isOn)
                {
                    // Bottom Circle and  Bout and + charge buttons are off (starting off state is the darker color shows and this represents Bout and +charge)
                    Debug.Log("Bout && Pos charge: " + (!Bin.isOn && !ChargeNeg.isOn));
                    //this.gameObject.SetActive(true);
                    PosCharge.SetActive(true);
                    NegCharge.SetActive(false);
                    sign = 1;
                    MoveCharge();
                }
                else if (Bin.isOn && ChargeNeg.isOn)
                {
                    // Bottom Circle and  Bout and + charge buttons are off (starting off state is the darker color shows and this represents Bout and +charge)
                    //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                    
                    PosCharge.SetActive(true);
                    NegCharge.SetActive(false);
                    sign = 1;
                    MoveCharge();
                }
                else //this means the top circle is in play because the toggles don't require the bottom circle to rotate
                {
                    //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                    //this.gameObject.SetActive(false);
                    PosCharge.SetActive(false);
                    NegCharge.SetActive(false);
                }
            }
            else
            {
                //this.gameObject.SetActive(false);
            }

            if(!isBottomCircle) //this means top circle is in play
            {
                this.gameObject.SetActive(true);
                if (Bin.isOn && !ChargeNeg.isOn)
                {
                    // Bottom Circle and  Bout and + charge buttons are off (starting off state is the darker color shows and this represents Bout and +charge)
                    //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                    //this.gameObject.SetActive(true);
                    PosCharge.SetActive(true);
                    NegCharge.SetActive(false);
                    sign = -1;
                    MoveCharge();
                }
                else if (!Bin.isOn && ChargeNeg.isOn)
                {
                    //this.gameObject.SetActive(true);
                    //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                    PosCharge.SetActive(false);
                    NegCharge.SetActive(true);
                    sign = -1;
                    MoveCharge();
                }
                else //this means the bottom circle is in play
                {
                    //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                    //this.gameObject.SetActive(false);
                    PosCharge.SetActive(false);
                    NegCharge.SetActive(false);
                }
            }
            else
            {
                //Debug.Log("B toggle is: " + Bin.isOn + "  Charge toggle is: " + ChargeNeg.isOn);
                //this.gameObject.SetActive(false);
            }
           //store the toggle values so these actions only happen on the change of button state
            tempB = Bin.isOn;
            tempCharge = ChargeNeg.isOn;
        }


    }
    public void MoveCharge()
    {

        transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle
        rotationAngle = 10 * sign; //this increments the angle by +10 or -10

    }
//    public void valueBChanged()
//    {
//        BbuttonState = Bin.isOn;
//        ChargeButtonState = ChargeNeg.isOn;
//    }
}
