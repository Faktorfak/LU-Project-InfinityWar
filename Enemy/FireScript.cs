using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    BoxCollider2D bc;
    SpriteRenderer sr;
    public HealthBar healthBar;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Boss2.isEnrged) {
            // Enable the sprite renderer and box collider of the fireball 
            sr.enabled = true;
            bc.enabled = true;
        }
        if (!Boss2.isEnrged)
        {
            // Disable the sprite renderer and box collider of the fireball
            sr.enabled = false;
            bc.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "FIRE")
        {
            healthBar.Damage(0.002f);

        }
    }
}
