using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockObject BlockObject;

    private Rigidbody2D _rb;
    private Camera _camera;

    private static List<GameObject> _blocks = new List<GameObject>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        float bottomBound = _camera.transform.position.y - _camera.orthographicSize * _camera.aspect;
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


    //    public bool IsStandingOnFloor() //????? ?? ????????, ?? ? ???????. ?? ????? ???????????.
    //    {
    //        _blocks.Add(gameObject);
    //        List<Collider2D> colliders = new List<Collider2D>();
    //        int countColliders = _rb.GetContacts(colliders);
    //        //print(gameObject.name + " " + countColliders.ToString());

    //        if (countColliders == 0)
    //        {
    //            _blocks.Remove(gameObject);
    //            return false;
    //        }
    //        foreach(Collider2D collider in colliders)
    //        {
    //            if (!_blocks.Exists(x => x.gameObject == collider.gameObject))
    //            {
    //                //print(collider.tag);
    //                if (collider.CompareTag("Floor"))
    //                    return true;
    //                if (collider.CompareTag("Block"))
    //                    if (collider.GetComponent<Block>().IsStandingOnFloor())
    //                        return true;

    //            }
    //        }
    //        _blocks.Remove(gameObject);
    //        return false;
    //    }
}
