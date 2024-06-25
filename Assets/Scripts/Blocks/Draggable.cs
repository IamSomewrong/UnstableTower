using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetJoint2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour
{
    TargetJoint2D _targetJoint;
    void Start()
    {
        _targetJoint = GetComponent<TargetJoint2D>();
    }


    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetJoint.enabled = true;
        _targetJoint.anchor = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) / transform.localScale.x;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetJoint.target = mousePosition;
    }

    private void OnMouseUp() 
    { 
        _targetJoint.enabled = false;
    }

}
