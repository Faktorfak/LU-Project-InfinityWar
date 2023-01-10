using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rbfb;
    private BoxCollider2D bcfb;
    private Transform player;
    [SerializeField]private float speed;
    private GameObject hp;
    private SpriteRenderer srfb;

    void Start()
    {
        rbfb = GetComponent<Rigidbody2D>();
        bcfb = GetComponent<BoxCollider2D>();
        srfb = GetComponent<SpriteRenderer>();
        hp = GameObject.Find("Bar");
        player = GameObject.Find("aim").GetComponent<Transform>();
        rbfb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    
    // Update is called once per frame
    void Update()
    {
        // Check if the boss2 is in an enraged state
        if (Boss2.isEnraged2)
        {
            // Remove constraints on the fireball's rigidbody
            rbfb.constraints = RigidbodyConstraints2D.None;
            // Enable the sprite renderer and box collider of the fireball
            srfb.enabled = true;
            bcfb.enabled = true;

            // Create a target position for the fireball to move towards
            Vector2 target = new Vector2(player.position.x, player.position.y);
            // Move the fireball towards the target position at the specified speed
            Vector2 newPos = Vector2.MoveTowards(rbfb.position, target, speed * Time.fixedDeltaTime);
            rbfb.MovePosition(newPos);

        }
 
        if (!Boss2.isEnraged2)
        {
            // Disable the sprite renderer and box collider of the fireball
            srfb.enabled = false;
            bcfb.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the object that collides with this object has a tag of "Hero"
        if (hitInfo.tag == "Hero")
        {

            hp.GetComponent<HealthBar>().Damage(0.1f);
            // Destroy the game object
            Destroy(gameObject);
        }

    }
}
