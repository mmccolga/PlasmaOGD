using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECRFelectrons : MonoBehaviour
{
    Vector3 _iRot, _iPos;
    public float angle = 180;
    private float move_zdir = (float)2.0;
    public Vector3 increaseValues = new Vector3(0, 0, 1.0f);
    public GameObject targetPosition;
    public GameObject spawnObject;
    public GameObject electronParent;
    private Vector3 _finalPos;
    public float spawnRate;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {


    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _iRot = spawnObject.transform.localEulerAngles;
        spawnObject.transform.Rotate(_iRot.x, _iRot.y, angle * Time.deltaTime);
        Debug.Log("electron: " + spawnObject.transform.localPosition + " target: " + targetPosition.transform.localPosition);
        if (spawnObject.transform.localPosition != targetPosition.transform.localPosition)//(Vector3.Distance(targetPosition.transform.localPosition, electronInstance.transform.position) > 0.2f)
        {

            Vector3 newPos = Vector3.MoveTowards(spawnObject.transform.localPosition, targetPosition.transform.localPosition, speed * Time.deltaTime);
            spawnObject.transform.localPosition = newPos;

        }
        if (spawnObject.transform.localPosition == targetPosition.transform.localPosition)
        {

        }


    }

}

