using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ArrowHeadScaler : MonoBehaviour
{

    public Vector3 arrowHeadScale;
    private Vector3 _parentOriginalScale;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        
        if (arrowHeadScale == Vector3.zero)
            arrowHeadScale = _transform.localScale;
        
        _parentOriginalScale = _transform.parent.localScale;
    }

    private void LateUpdate() {
        Vector3 currentParentScale = transform.parent.localScale;


        // Get the relative difference to the original scale
        float yDiff = currentParentScale.y / _parentOriginalScale.y;

        // This inverts the scale differences
        if (yDiff != 0) {
            yDiff = 1 / yDiff;
        }

        // Apply the inverted differences to the original scale
        _transform.localScale = new Vector3(arrowHeadScale.x, arrowHeadScale.y * yDiff, arrowHeadScale.z);
    }
}
