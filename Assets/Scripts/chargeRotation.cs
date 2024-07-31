using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class chargeRotation : MonoBehaviour
{

    public Transform Center;
    private float _horizontalMove;
    private float _verticalMove;
    private Vector3 _chargePosition;
    [SerializeField] private float _radius = .7f;
    public TMP_Text charge_xyz;
    public TMP_Text zangle;
    public TMP_Text centrpos;


    private void Update()
    {
        _chargePosition = _radius * Vector3.Normalize(this.transform.position - Center.position) + Center.position;
        charge_xyz.text = _chargePosition.ToString();
        centrpos.text = Center.position.ToString();
        _verticalMove = Input.GetAxisRaw("Vertical");
        zangle.text = _verticalMove.ToString();
        this.transform.position = _chargePosition;
        transform.RotateAround(Center.position, Vector3.forward, _verticalMove);

    }
}