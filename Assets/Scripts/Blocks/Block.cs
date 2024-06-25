using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockObject BlockObject;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

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
