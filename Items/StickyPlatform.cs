using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickyPlatform : MonoBehaviour
{
    public Transform HERO;

    private void Start()
    {
        //new Vector2 = HERO.transform.localScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hero1") 
        {
            collision.transform.SetParent(transform, true);
            
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Hero1")
        {
            collision.transform.SetParent(null);
        }

    }
}
