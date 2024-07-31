using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARStaticVarHolder : MonoBehaviour
{
    public static bool wasWarned;
    // Start is called before the first frame update
    void Start()
    {
        wasWarned = false;
        print(wasWarned);
    }

    // Update is called once per frame
    void Update()
    {
        print(wasWarned);
    }
}
