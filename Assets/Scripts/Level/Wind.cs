using System.Collections;
using System.Linq;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public WindObject WindObject;

    private Vector3 oldPos;
    
    private float nextWindTime;
    private bool isWindActive = false;

    void Start()
    {
        oldPos = transform.position;
        nextWindTime = Time.time + WindObject.windInterval;
    }

    void Update()
    {
        if (Time.time >= nextWindTime)
        {
            StartCoroutine(ApplyWind());
            nextWindTime = Time.time + WindObject.windInterval + WindObject.windDuration;
        }

        if (isWindActive)
        {
            ApplyWindAnimation();
        }
        else
        {
            transform.position = oldPos;
        }
    }

    private IEnumerator ApplyWind()
    {
        isWindActive = true;
        float endTime = Time.time + WindObject.windDuration;
        while (Time.time < endTime)
        {
            var rigidbodies = FindObjectsOfType<Rigidbody2D>();
            
            foreach (var rb in rigidbodies)
            {
                rb.AddForce(transform.up * WindObject.windForce, ForceMode2D.Force);
            }
            yield return null;
        }
        isWindActive = false;
    }

    private void ApplyWindAnimation()
    {
        // Небольшое изменение позиции для создания эффекта дергания
        float shakeAmount = 0.1f;
        Vector3 originalPosition = transform.position;
        
        float offsetX = Random.Range(-shakeAmount, shakeAmount);
        float offsetY = Random.Range(-shakeAmount, shakeAmount);

        transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);
    }
}
