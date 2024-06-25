using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public LevelObject LevelObject;

    public void ChangeScene()
    {
        Global.LevelObject = LevelObject;
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
