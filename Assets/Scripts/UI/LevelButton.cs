using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Global.Instance.LevelObject = LevelObject;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
