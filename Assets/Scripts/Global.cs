using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public static Global Instance = null;
    public LevelObject LevelObject;
    public float Timer = 3f;
    public List<LevelObject> Levels;
    [SerializeField]
    private GameObject _levelButtonSample;
    [SerializeField]
    private GameObject _buttonsPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (var level in Levels)
        {
            GameObject button = Instantiate(_levelButtonSample, _buttonsPanel.transform);
            button.GetComponentInChildren<LevelButton>().LevelObject = level;
        }

    }

    public void ChangeLevel(LevelObject level)
    {
        LevelObject = level;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
