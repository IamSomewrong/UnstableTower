using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName ="NewLevel", menuName = "Level")]
public class LevelObject : ScriptableObject
{
    [FormerlySerializedAs("Blocks")] public List<BlockObject> BlockTypes;
	public List<GameObject> Blocks;
    public float Height;
    public WindObject Wind;
    
    public bool Passed;
}
