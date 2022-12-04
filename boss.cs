using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
	Transform player;
    Rigidbody2D rb;
    public float speed = 5.5f;
   
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;

        if (rb.position.x != leftEdge.position.x || rb.position.x != rightEdge.position.x)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else { }

    }
}
