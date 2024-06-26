using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance = null;
    public LevelObject LevelObject;
    public float Timer = 3f;
    [SerializeField]
    private List<LevelObject> _levels;
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
        foreach (var level in _levels)
        {
            GameObject button = Instantiate(_levelButtonSample, _buttonsPanel.transform);
            button.GetComponentInChildren<LevelButton>().LevelObject = level;
        }

    }
}
