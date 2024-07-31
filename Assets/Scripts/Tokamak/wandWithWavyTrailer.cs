using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wandWithWavyTrailer : MonoBehaviour
{ 
    public GameObject endPoint;
    public float speed;
    public float frequency;
    public float amplitude;
    private float _speed, _amplitude, _frequency;

    private bool isOn = false;

    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        _speed = speed;
        t = transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            transform.position = t.position;
            Debug.Log("movingX: " + transform.position.x + "endX: " + endPoint.transform.position.x);
            if (transform.position.x <= endPoint.transform.position.x)
            {
                _speed = 0;
                _amplitude = 0;
                _frequency = 0;
                isOn = false;
            }
            else
            {
                _speed = speed;
                _amplitude = amplitude;
                _frequency = frequency;
            }
            transform.LookAt(endPoint.transform);
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, _speed);
            transform.position += transform.up * Mathf.Cos(_frequency * Time.time) * _amplitude;
        }
        
       
    }

    public void EMWavesOn()
    {
        
        isOn = true;


    }
}
