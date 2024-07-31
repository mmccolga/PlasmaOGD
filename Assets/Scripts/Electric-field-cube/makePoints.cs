using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makePoints : MonoBehaviour
{
    [SerializeField] float distance; //is related to how big we want the cube of arrows to be
    [SerializeField] int density;//is related to how many arrows we want and how to space them
    [SerializeField] GameObject mother;
    [SerializeField] int chargeNumber;
    [SerializeField] int chargeMagnitudeMultiplier;

    [SerializeField] GameObject objectWeAreCreating;
    float xtail, ytail, ztail;
    float arrowLength;
    Vector3 scaleChange;
    Quaternion angle;
    public GameObject[] charges;
    public GameObject[,,] arrowArray;
    public int numArrowsPerSide;


    public Slider numChargesSlider;
    public Slider chargeMagnitudeSlider;
    int i;

   
    void Start()
    {
        //the 3 in this equation is just by trial and error. It doesn't make sense
        arrowLength = 3*(distance / (density));
        scaleChange = new Vector3(1f, arrowLength*1f, 1f);
        chargeNumber = 4;
        numChargesSlider.value = 1f; //start out with 1 charge
        numChargesSlider.minValue = 0f; //min number of charges is zero
        numChargesSlider.maxValue = 4f; //max # of charges is 4
        chargeMagnitudeSlider.value = 0f; //start with charge value of zero
        chargeMagnitudeSlider.maxValue = 5f; //positive charge values
        chargeMagnitudeSlider.minValue = -5f; //negative charge values

        numArrowsPerSide = density + 1;
        arrowArray = new GameObject[numArrowsPerSide, numArrowsPerSide, numArrowsPerSide];
        

        objectWeAreCreating.transform.localScale = scaleChange;
        angle = Quaternion.Euler(0, 0, 0);


        
    

        //the number of arrows is density + 1
        for (uint x = 0; x < numArrowsPerSide; x++)
        {
            xtail = -distance / 2 + x *distance / density;
            //xdot = xdot / 10;
            for (uint y = 0; y < numArrowsPerSide; y++)
            {


                //ytail = -distance / 2 + y * distance / density;
                ytail = 1 + y * distance / density;

                //ydot = ydot / 10;

                for (uint z = 0; z < numArrowsPerSide; z++)
                {
                    ztail = -distance / 2 + z *  distance / density;
                    //zdot = zdot / 10;
                    
                    arrowArray[x,y,z] = Instantiate(objectWeAreCreating, new Vector3(xtail, ytail, ztail), angle, mother.transform);
                }
            }
        }
    }

    private void Update()
    {
        for(i= 0;i < numChargesSlider.maxValue;i++)
        {
            if (i < numChargesSlider.value)
            {
                charges[i].SetActive(true);
            }
            else
            {
                charges[i].SetActive(false);
            }
        }

        //the number of arrows is density + 1
        for (uint x = 0; x < numArrowsPerSide; x++)
        {
            xtail = -distance / 2 + x * distance / density;
            //xdot = xdot / 10;
            for (uint y = 0; y < numArrowsPerSide; y++)
            {


                //ytail = -distance / 2 + y * distance / density;
                ytail = 1 + y * distance / density;

                //ydot = ydot / 10;

                for (uint z = 0; z < numArrowsPerSide; z++)
                {
                    ztail = -distance / 2 + z * distance / density;
                    //zdot = zdot / 10;


               
                    Vector3 arrowDir = charges[0].transform.position - arrowArray[x,y,z].transform.position;
                    float arrowAngle = Vector3.Angle(arrowDir, transform.forward);
                    arrowArray[x, y, z].transform.LookAt(charges[0].transform.position);
                    
                }
            }
        }




    }
}



