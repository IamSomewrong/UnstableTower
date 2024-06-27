using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerPanel : MonoBehaviour
{
    public void NextLevel()
    {
        int nextIndex = Global.Instance.Levels.FindIndex(x => x == Global.Instance.LevelObject) + 1;
        if (Global.Instance.Levels[nextIndex] != null )
            Global.Instance.ChangeLevel(Global.Instance.Levels[nextIndex]);
    }

    public void Menu()
    {
        Global.Instance.MoveToMenu();
    }

}
