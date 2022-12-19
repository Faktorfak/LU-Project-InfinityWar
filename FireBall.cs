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

    void Start()
    {
        rbfb = GetComponent<Rigidbody2D>();
        bcfb = GetComponent<BoxCollider2D>();
        hp = GameObject.Find("Bar");
        player = GameObject.Find("aim").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
       
        Vector2 newPos = Vector2.MoveTowards(rbfb.position, target, speed * Time.fixedDeltaTime);
        rbfb.MovePosition(newPos);
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
