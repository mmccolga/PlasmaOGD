using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VectorHandler : MonoBehaviour
{
    public TMP_InputField Bfield;
    public TMP_InputField velocity;

    private float _length;
    private float _x;
    private float _y;
    private float _z;
    private float _thetaX;  // X AND Y THETAS ARE REVERSED IN UI INTENTIONALLY
    private float _thetaY;
    private Vector3 _initPos;
    private Vector3 _initScale;
    private Vector3 _initRotation;

    private float _B;
    private float _v;
    private float _R;
    
    private void Start()
    {
        Transform t = transform;
        _initPos = t.localPosition;
        _initScale = t.localScale;
        _initRotation = t.eulerAngles;

        _length = _initScale.y;
        _x = _initPos.x;
        _y = _initPos.y;
        _z = _initPos.z;
        _thetaX = _initRotation.x;
        _thetaY = _initRotation.y;
        _B = 1;
        _v = 1;
        _R = 1;
    }

    public void Setv()
    {
        try
        {

            _v = velocity.text != "" ? float.Parse(velocity.text) / 4 : 0;
            if (_v != 0 & _B != 0)
            {
                transform.Rotate(Vector3.forward, _v * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.forward, 0 * Time.deltaTime);
            }

        }
        catch (FormatException e) {}
    }

    public void SetR()
    {
        try
        {
            _v = velocity.text != "" ? float.Parse(velocity.text) / 4 : 0;
            _B = Bfield.text != "" ? float.Parse(Bfield.text) / 4 : 0;
            if (_v != 0 & _B != 0)
            {
                _R = transform.position.y * _v / _B;
            }
            else
            {
                _R = transform.position.y;
            }
            transform.position = new Vector3(transform.position.x, _R, transform.position.z);
        }
        catch (FormatException e) {}
    }

    
}
