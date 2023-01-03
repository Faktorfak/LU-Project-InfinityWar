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
        if (Boss2.isEnraged2)
        {
            rbfb.constraints = RigidbodyConstraints2D.None;
            srfb.enabled = true;
            bcfb.enabled = true;

            Vector2 target = new Vector2(player.position.x, player.position.y);

            Vector2 newPos = Vector2.MoveTowards(rbfb.position, target, speed * Time.fixedDeltaTime);
            rbfb.MovePosition(newPos);

        }
 
        if (!Boss2.isEnraged2)
        {
            srfb.enabled = false;
            bcfb.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Hero")
        {

            hp.GetComponent<HealthBar>().Damage(0.1f);
            Destroy(gameObject);
        }

    }
}
