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

    void Update()
    {
        if (BossHealth.bossIsAlive == true)//Check if the boss is still alive
        {
            if (BossHealth.bossIsEnraged == true)//Check if the boss is in an "enraged" state
            {
                float t = (Mathf.Sin(Time.time - startTime) * speed);// Calculate a value that oscillates between - 1 and 1 over time
                //Use the value to interpolate between the start and end color of the object's material
                GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            }
        }
    }
}
