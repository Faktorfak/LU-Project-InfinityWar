using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D bc;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        sr.enabled = false;
        bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss2.isEnraged2 == true) 
        {
            sr.enabled = true;
            bc.enabled = true;
        }
        
    }
}
