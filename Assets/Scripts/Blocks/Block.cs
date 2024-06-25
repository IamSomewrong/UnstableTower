using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private BlockObject _blockObject;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        PhysicsMaterial2D pm = new PhysicsMaterial2D();

        if (_blockObject == null)
            _blockObject = ScriptableObject.CreateInstance<BlockObject>();

        pm.friction = _blockObject.Friction;
        pm.bounciness = _blockObject.Bounciness;
        _rb.sharedMaterial = pm;
        _rb.mass = _blockObject.Weight;
    }
}
