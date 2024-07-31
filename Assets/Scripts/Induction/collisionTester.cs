using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script works with the script CollisionCounter script
//This collisionCounter script is added to ring in the copperRingInteractive empty game object
//The CollisionTester script gets attached to ALL of the arrows in the Interactive Arrows Sim and within each
//of the game objects x2IntenseSpeeds, x3IntenseSpeeds, x5IntenseSpeeds, x10IntenseSpeeds. Within each arrow, game object
//the CollisionTester script is attached to the first game object named group_0...
//To see the numbers change, onscreen, uncomment the method OnGui() and make sure the game object BArrowCounter has the collisionCounter script

public class collisionTester : MonoBehaviour
{

    // https://www.youtube.com/watch?v=fMd3B0T5ow0
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "ringEmpty")
        {
            Debug.Log("Trigger");
            collisionCounter.Count += 1;

            //DestroyImmediate(GetComponent<BoxCollider>());

            //GetComponents<BoxCollider>().Equals;
            //GetComponent<BoxCollider>().isTrigger = true;

            //GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "ringEmpty")
        {
            Debug.Log("Stay");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.transform.name == "ringEmpty")
        {
            // https://www.youtube.com/watch?v=R5XIncKWL28
            collisionCounter.Count -= 1;
            //GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
