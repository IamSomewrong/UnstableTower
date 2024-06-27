using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LevelObject LevelObject;

    private void Start()
    {
        transform.parent.GetComponent<Image>().enabled = !LevelObject.Passed;
    }

    public void ChangeScene()
    {
        Global.Instance.ChangeLevel(LevelObject);
    }
}
