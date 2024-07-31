using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerateCharge : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab to instantiate.
    public GameObject Efield;
    public GameObject plusSign1, plusSign2,minusSign1,minusSign2;
    public GameObject posBluePlate1, posBluePlate2, posBluePlate3, posBluePlate4;
    public GameObject negRedPlate1, negRedPlate2, negRedPlate3, negRedPlate4;

    public float acceleration = 5.0f; // Public acceleration value.
    private float accel;
    public float totalDistance = 10.0f; // Total distance to travel.
    public Toggle isFieldOn;

    private float currentSpeed = 0.0f;
    private float traveledDistance = 0.0f;
    private bool isMoving = false;

    public Material redMaterial, blueMaterial, greyMaterial;

    private void Update()
    {
        //sets the accel to 1 if the E field is on and 0 if it's not
        //give the ion a positive starting velocity if the E field is off otherwise it won't move
        //Changes the color of the plates to grey if the field is off, blue/red
        if (Efield.activeSelf)
        {
            accel = 1 * acceleration;
            ChangePlateColorSign();
        }
        else
        {
            accel = 0;
            currentSpeed = (float)0.5;//needs a starting speed
            ChangePlateColorSign();
        }
        if (isMoving)
        {
            currentSpeed += accel * Time.deltaTime;
            

            // Calculate the distance traveled in this frame.
            float distanceThisFrame = currentSpeed * Time.deltaTime;

            // Update the total traveled distance.
            traveledDistance += distanceThisFrame;

            // Move the object.
            transform.Translate(Vector3.right * distanceThisFrame);

            // Check if the object has reached the total distance.
            if ((traveledDistance >= totalDistance))
            {
                isMoving = true; //stops the ion from moving

                //Turns off the ion, moves it to the starting position, then turns it on
                gameObject.SetActive(false);
                gameObject.transform.localPosition = new Vector3((float)-0.585, 0, (float)-0.06);
                gameObject.SetActive(true);
                currentSpeed = 0.5f;
                traveledDistance = 0.0f;
            }
        }
    }

    public void StartMovingOnClick()
    {
        if (!isMoving)
        {
            // Reset the state variables and start moving.
            currentSpeed = 0.5f;
            traveledDistance = 0.0f;
            isMoving = true;
        }
    }

    public void ChangePlateColorSign()
    {
        if(!Efield.activeSelf)
        {
            //Changes the color the capacitor plates to grey when the E field is off
            //Hides the positive and negative signs on the capacitor plates
            posBluePlate1.GetComponent<MeshRenderer>().material = greyMaterial;
            posBluePlate2.GetComponent<MeshRenderer>().material = greyMaterial;
            posBluePlate3.GetComponent<MeshRenderer>().material = greyMaterial;
            posBluePlate4.GetComponent<MeshRenderer>().material = greyMaterial;
            negRedPlate1.GetComponent<MeshRenderer>().material = greyMaterial;
            negRedPlate2.GetComponent<MeshRenderer>().material = greyMaterial;
            negRedPlate3.GetComponent<MeshRenderer>().material = greyMaterial;
            negRedPlate4.GetComponent<MeshRenderer>().material = greyMaterial;
            plusSign1.SetActive(false);
            plusSign2.SetActive(false);
            minusSign1.SetActive(false);
            minusSign2.SetActive(false);
            
        }
        else 
        {
            //Changes the color the capacitor plates to blue and red when the E field is on
            //Makes the positive and negative signs active on the capacitor plates
            posBluePlate1.GetComponent<MeshRenderer>().material = blueMaterial;
            posBluePlate2.GetComponent<MeshRenderer>().material = blueMaterial;
            posBluePlate3.GetComponent<MeshRenderer>().material = blueMaterial;
            posBluePlate4.GetComponent<MeshRenderer>().material = blueMaterial;
            negRedPlate1.GetComponent<MeshRenderer>().material = redMaterial;
            negRedPlate2.GetComponent<MeshRenderer>().material = redMaterial;
            negRedPlate3.GetComponent<MeshRenderer>().material = redMaterial;
            negRedPlate4.GetComponent<MeshRenderer>().material = redMaterial;
            plusSign1.SetActive(true);
            plusSign2.SetActive(true);
            minusSign1.SetActive(true);
            minusSign2.SetActive(true);
        }

    }
}




//public class AccelerateCharge : MonoBehaviour
//{
//    public GameObject ion;

//    private bool isPressed = false;
//    public float acceleration = 5.0f; // Public acceleration value.
//    public float totalDistance = 10.0f; // Total distance to travel.
//    public Toggle isFieldOn;

//    private float currentSpeed = 0.0f;
//    private float traveledDistance = 0.0f;




//    void Update()
//    {
//        if (isFieldOn)
//        {// Calculate the new speed using the acceleration.
//            currentSpeed += acceleration * Time.deltaTime;
//        }
//        else
//        {    // if isFieldOn is false, acceleration is zero.
//            currentSpeed += 0 * Time.deltaTime;
//        }

//        if (Input.GetButtonDown("Fire3") || isPressed)
//        {
//            GameObject ball = Instantiate(ion, new Vector3((float)-0.567,0,(float)-0.056),
//                                                      transform.localRotation) as GameObject;
//            // Set a new initial velocity for the instantiated object.
//            Rigidbody newBallRigidbody = ball.GetComponent<Rigidbody>();
//            if (newBallRigidbody != null)
//            {
//                newBallRigidbody.velocity = Vector3.forward * currentSpeed;
//            }

//            Debug.Log("start position: " + ball.transform.localPosition);

//            currentSpeed += acceleration * Time.deltaTime;

//            // Calculate the distance traveled in this frame.
//            float distanceThisFrame = currentSpeed * Time.deltaTime;

//            // Update the total traveled distance.
//            traveledDistance += distanceThisFrame;

//            // Move the object.
//            ball.transform.Translate(Vector3.right * distanceThisFrame);
//            Debug.Log("end position: " + ball.transform.position);
//            // Check if the object has reached the total distance.
//            if (traveledDistance >= totalDistance)
//            {

//                // Destroy the old object.
//                Destroy(ball,3f);
//            }






//            //Destroy(ball, 3f);
//            //ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
//            //                                  (0, acceleration, 0));//launchVelocity
//            isPressed = false;
//        }
//    }

//    public void FireProjectile()
//    {
//        isPressed = true;
//    }




//}

