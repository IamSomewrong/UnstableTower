using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour
{
    private TargetJoint2D _targetJoint;

    void Start()
    {
        _targetJoint = GetComponent<TargetJoint2D>();
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 
        
        _targetJoint.enabled = true;
        Vector2 localAnchor = transform.InverseTransformPoint(mousePosition);
        _targetJoint.anchor = localAnchor;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        _targetJoint.target = mousePosition;
    }

    private void OnMouseUp()
    {
        _targetJoint.enabled = false;
    }
}
