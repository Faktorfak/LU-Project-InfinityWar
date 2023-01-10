using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//specila for one boss faze
public class FirstAid : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D bc;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        // Disable the sprite renderer and box collider components
        sr.enabled = false;
        bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss2.isEnraged2 == true) 
        {
            // Enable the sprite renderer and box collider components
            sr.enabled = true;
            bc.enabled = true;
        }
        
    }
}
