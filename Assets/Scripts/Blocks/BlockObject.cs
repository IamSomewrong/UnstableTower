using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlock", menuName ="Block")]
public class BlockObject : ScriptableObject
{
    public float Friction = 0.4f;
    public float Bounciness = 0;
    public float Weight = 1;
    public float Scale = 1;
    public BlockForm Form = BlockForm.Square;
}
