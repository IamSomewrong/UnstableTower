using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="NewLevel", menuName = "Level")]
public class LevelObject : ScriptableObject
{
    public List<BlockObject> Blocks;
    public float Height;

    public bool Passed;
}
