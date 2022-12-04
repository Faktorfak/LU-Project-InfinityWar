using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
	Transform player;
    Rigidbody2D rb;
    public float speed = 5.5f;

	

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
