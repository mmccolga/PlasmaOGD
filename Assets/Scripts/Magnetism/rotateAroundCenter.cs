using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rotateAroundCenter : MonoBehaviour
{
    private float angle = 0f;
    [SerializeField] private float selfRotateAngle = 0f;
    //[SerializeField] private float angle = 0f
    [SerializeField] private float orbitSpeed = 1f;
    [SerializeField] private float orbitRadius = 5f;
    [SerializeField] private float selfRotateSpeed = 0f;
    // Update is called once per frame
    void Update()
    {
        //print(angle);
        var xPos = orbitRadius * Mathf.Cos(angle);
        var zPos = orbitRadius * Mathf.Sin(angle);
        transform.localPosition = new Vector3(xPos, 0f, zPos);
        angle += orbitSpeed * Time.deltaTime;
        //Rotate is by Space.Self by default!!!
        transform.Rotate(selfRotateAngle, 0f , 0f);
        //selfRotateAngle += selfRotateSpeed * Time.deltaTime;
    }
}







