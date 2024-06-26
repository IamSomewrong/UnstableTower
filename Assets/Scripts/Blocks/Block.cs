using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockObject BlockObject;

    private Rigidbody2D _rb;
    private Camera _camera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        float bottomBound = _camera.transform.position.y -  _camera.orthographicSize * _camera.aspect;
        if (transform.position.y <= bottomBound)
        {
            Vector3 cameraPosition = _camera.transform.position;
            _rb.velocity = Vector2.zero;
            _rb.position = cameraPosition;
        }
            
    }
    public void UpdateObject(BlockObject? blockObject)
    {
        BlockObject = blockObject;
        PhysicsMaterial2D pm = new PhysicsMaterial2D();

        if (BlockObject == null)
            BlockObject = ScriptableObject.CreateInstance<BlockObject>();

        pm.friction = BlockObject.Friction;
        pm.bounciness = BlockObject.Bounciness;
        _rb.sharedMaterial = pm;
        _rb.mass = BlockObject.Weight;

        gameObject.transform.localScale *= BlockObject.Scale;
    }
}
