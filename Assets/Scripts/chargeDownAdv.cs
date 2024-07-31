using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class chargeDownAdv : MonoBehaviour
{
	Transform t; //using this to read the rotation transform
	private int rotationAngle; //this is the angle to advance the particle
	Vector3 _initRotation; //this stores the current rotation transform
	private bool isClicked; //this checks to see if the next button is clicked
	private int sign;  //this is +1 for the particle moving down and -1 for particle moving up
	private bool isBout, isChargePositive;// the toggle buttons for B and charge changes these values
	private bool BisChanged, chargeIsChanged; //if either of these is true, the rotationAngle goes back to zero
	public GameObject Bout, Bin;
	public GameObject chargePos, chargeNeg;
	public GameObject force1,force2;

	void Start()
	{ 
		 
		rotationAngle = 0;
		t = transform;
		_initRotation = t.localEulerAngles; //get the rotation transform
		isClicked = false; // start out with the button not clicked
		transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle


		isBout = Bout.activeSelf;
		//this sets the sign of the rotation as positive for a positive charge
		//or negative depending on which way you need to rotate.
		if ((isChargePositive & isBout) |(!isChargePositive & !isBout))
        {
			sign = 1;
        }
        else
        {
			sign = -1;
        }
		rotationAngle = 10 * sign; //this increments the angle by +10 or -10
	}

    private void Update()
    {
		isBout = Bout.activeSelf;
		
		if(isClicked)
        {
			if ((!BisChanged & !chargeIsChanged) & (sign * rotationAngle <= 60)) //limits the rotation to 60 degrees to stay inside the B field
			{
				transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle); //sets the angle of the game object
				isClicked = false; //sets the button press back to false
				rotationAngle = rotationAngle +sign*10; // increments the angle by +10 or -10
			}
            else
            {
				rotationAngle = 0; //sets the angle back to zero
				transform.localEulerAngles = new Vector3(_initRotation.x, _initRotation.y, rotationAngle);
				isClicked = false;
				BisChanged = false;
				chargeIsChanged = false;

			}
        }
	}

	//this function is called using OnClick - if isClicked is true, the game object rotates
    public void rotateMe()
	{
			isClicked = true; 

	}

	public void Fchange()
    {
		isBout = Bout.activeSelf;
		
		//if(isBout ==true)
  //      {
		//	Bout.SetActive(true);
		//	Bin.SetActive(false);
		//	force1.SetActive(true);
		//	force2.SetActive(false);
		//}
  //      else
  //      {
		//	Bout.SetActive(false);
		//	Bin.SetActive(true);
		//	force1.SetActive(false);
		//	force2.SetActive(true);
		//}
		BisChanged = true;
    }

	//public void chargeChange()
 //   {
	//	isChargePositive = chargePos.activeSelf;
	//	//if (isChargePositive == true)
	//	//{
	//	//	chargePos.SetActive(true);
	//	//	chargeNeg.SetActive(false);
	//	//}
	//	//else
	//	//{
	//	//	chargePos.SetActive(false);
	//	//	chargeNeg.SetActive(true);
	//	//}
	//	chargeIsChanged = true;

	//}
	
}