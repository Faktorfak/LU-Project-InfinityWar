using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject hp;
    public SpriteRenderer spi;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
        if (RangeEnemy.shootingSide == 1)
        {
            rb.velocity = transform.right * speed;
            spi.flipX = false;
        }
        if (RangeEnemy.shootingSide == -1) 
        {
            rb.velocity = transform.right * speed * -1;
            spi.flipX = true;
        }
            hp = GameObject.Find("Bar");

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Hero") {

            hp.GetComponent<HealthBar>().Damage(0.1f);
            Destroy(gameObject);
        }
       
    }


}
