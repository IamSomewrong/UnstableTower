using System.Collections;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windForce = 10f; // Сила ветра
    public float windDuration = 2f; // Длительность ветра
    public float windInterval = 5f; // Интервал между порывами ветра

    private float nextWindTime;

    void Start()
    {
        nextWindTime = Time.time + windInterval;
    }

    void Update()
    {
        if (Time.time >= nextWindTime)
        {
            StartCoroutine(ApplyWind());
            nextWindTime = Time.time + windInterval + windDuration;
        }
    }

    private IEnumerator ApplyWind()
    {
        float endTime = Time.time + windDuration;
        while (Time.time < endTime)
        {
            var rigidbodies = FindObjectsOfType<Rigidbody2D>();
            Debug.Log($"Found {rigidbodies.Length} rigidbodies");
            
            foreach (var rb in rigidbodies)
            {
                rb.AddForce(Vector3.right * windForce, ForceMode2D.Force);
            }
            yield return null;
        }
    }
}
