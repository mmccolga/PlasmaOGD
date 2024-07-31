using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script works with the script CollisionTester
//This script (collisionCounter) is added to ring in the copperRingInteractive empty game object
//The CollisionTester script gets attached to ALL of the arrows in the Interactive Arrows Sim and within each
//of the game objects x2IntenseSpeeds, x3IntenseSpeeds, x5IntenseSpeeds, x10IntenseSpeeds. Within each arrow, game object
//the CollisionTester script is attached to the first game object named group_0...
//To see the numbers change, onscreen, uncomment the method OnGui() and make sure the game object BArrowCounter has the collisionCounter script
public class collisionCounter : MonoBehaviour
{
    // https://www.youtube.com/watch?v=fMd3B0T5ow0
    public static byte Count;
    private int angle;
    private byte oldCount;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        oldCount = 0;
        angle = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 90);


    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 0.3f;
        angle = 20 * (Count - oldCount);
        if (Count > oldCount)
        {
            ringRotateCW();

        }
        else if (Count < oldCount)
        {
            ringRotateCCW();

        }
        else
        {
            ringRotateStop();

        }
        oldCount = Count;


    }

    //void OnGUI(){ //this is for testing whether the # of B field lines are changing
    //    GUI.Box(new Rect(1500, 100, 100, 100), Count.ToString());
    //    GUI.Box(new Rect(1500, 300, 100, 100), angle.ToString());

    //}

    void ringRotateCW()
    {
        //gameObject.transform.Rotate(0,-angle,0);
        //transform.RotateAround(gameObject.transform.position, Vector3.forward, 180-angle);
        gameObject.transform.Rotate(0, angle, 0); //keeps orientation of ring, rotates about x
    }

    void ringRotateCCW()
    {
        //gameObject.transform.Rotate(0, 360+angle, 0);
        //transform.RotateAround(gameObject.transform.position, Vector3.forward, angle);
        gameObject.transform.Rotate(0, -angle, 0);
    }

    void ringRotateStop()
    {
        gameObject.transform.Rotate(0, 0, 0);
    }



}
