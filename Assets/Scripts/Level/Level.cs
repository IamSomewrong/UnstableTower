using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelObject LevelObject;

    private List<GameObject> _blocks = new List<GameObject>();
    private GameObject _timer;
    private GameObject _winnerPanel;
   

    private void Start()
    {
        LevelObject = Global.Instance.LevelObject;
        _timer = GameObject.FindGameObjectWithTag("Timer");
        _winnerPanel = GameObject.FindGameObjectWithTag("WinnerPanel");
        _winnerPanel.SetActive(false);

        Vector3[] positions = new Vector3[2] { new Vector3(-10, LevelObject.Height, 0), new Vector3(10, LevelObject.Height, 0) };
        GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>().SetPositions(positions);
        StartCoroutine(SpawnAndWait());
    }

    private void Update()
    {
        if(_timer != null)
            _timer.SetActive(CheckTimer());
    }

    private bool CheckTimer()
    {
        foreach (var block in _blocks)
        {
            if (block.transform.position.y + block.transform.localScale.y / 2 >= LevelObject.Height &&
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y < LevelObject.Height)
            {
                Global.Instance.Timer -= Time.deltaTime;
                _timer.GetComponent<TMP_Text>().text = Global.Instance.Timer.ToString();
                if(Global.Instance.Timer <= 0)
                {
                    LevelObject.Passed = true;
                    _winnerPanel.SetActive(true);
                }
                return true;
            }
        }
        Global.Instance.Timer = 3f;
        return false;
    }

    IEnumerator SpawnAndWait()
    {
        for (var i = 0; i < LevelObject.BlockTypes.Count; i++)
        {
            var blockType = LevelObject.BlockTypes[i];
            var block = LevelObject.Blocks[i];
            
            GameObject spawned = Instantiate(block, new Vector3(Random.Range(-2, 2), 5, 0), Quaternion.identity);
            spawned.GetComponent<Block>().UpdateObject(blockType);
            _blocks.Add(spawned);
            yield return new WaitForSeconds(1);
        }
    }
}
