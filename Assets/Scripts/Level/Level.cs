using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private GameObject _block;

    public LevelObject LevelObject;

    private List<GameObject> _blocks = new List<GameObject>();
    private GameObject _timer;

    private void Start()
    {
        LevelObject = Global.LevelObject;
        _timer = GameObject.FindGameObjectWithTag("Timer");

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
                Global.Timer -= Time.deltaTime;
                _timer.GetComponent<TMP_Text>().text = Global.Timer.ToString();
                return true;
            }
        }
        Global.Timer = 3f;
        return false;
    }

    IEnumerator SpawnAndWait()
    {
        foreach (var block in LevelObject.Blocks)
        {
            GameObject spawned = Instantiate(_block, new Vector3(Random.Range(-2, 2), 5, 0), Quaternion.identity);
            spawned.GetComponent<Block>().UpdateObject(block);
            _blocks.Add(spawned);
            yield return new WaitForSeconds(1);
        }
    }
}
