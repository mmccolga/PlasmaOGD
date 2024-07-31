using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rotateCharge : MonoBehaviour
{
    float speed;
    float b;
    float r;

    private void Start()
    {
        speed = 100;
        b = 300;
        r = speed / b;
        //transform.position = new Vector3(0, r, 1);

    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);

    }

    public void speedUp()
    {

        if (speed < 300)
        {
            speed = speed + 50;
        }
        else
        {
            speed = speed;
        }
     }
    public void slowDown()
    {

        if (speed > 50)
        {
            speed = speed - 50;
        }
        else
        {
            speed = speed;
        }
    }


    public void Bup()
    {

        if (b < 300)
        {
            b = b + 300;
        }
        else
        {
            b = b;
        }
    }
    public void bDown()
    {

        if (b > 50)
        {
            b = b - 50;
        }
        else
        {
            b = b;
        }
    }

    public void Rotate()
    {
        speed = speed;
    }

    public void Stop()
    {
        speed = 0;
        //transform.position = new Vector3(0, (float)0.5, 1);
    }

}