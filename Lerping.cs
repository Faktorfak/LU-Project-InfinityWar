using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerping : MonoBehaviour
{
    public float speed = 1f;
    public Color startColor;
    public Color endColor;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealth.bossIsAlive == true)
        {
            if (BossHealth.bossIsEnraged == true)
            {
                float t = (Mathf.Sin(Time.time - startTime) * speed);
                GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            }
        }
    }
}
