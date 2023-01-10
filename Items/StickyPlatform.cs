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
    //When a collision is detected 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the colliding object has the name "Hero1"
        if (collision.gameObject.name == "Hero1") 
        {
            //The hero object becomes a child of this object, meaning it will move with this object
            collision.transform.SetParent(transform, true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //If the colliding object has the name "Hero1"
        if (collision.gameObject.name == "Hero1")
        {
            //The hero object is no longer a child of this object and will move independently
            collision.transform.SetParent(null);
        }

    }
}
