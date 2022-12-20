using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    Animator ganim;
    public BoxCollider2D gbc;
    Rigidbody2D grb;
    public LayerMask playerLayer;
    Transform player;
    public Transform playerTo;
    public bool isFlipped = false;

    [Header("Goblin Stats")]
    [SerializeField]private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float speed;
    void Start()
    {
        ganim = GetComponent<Animator>();
        
        grb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Hero").transform;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(gbc.bounds.size.x * range, gbc.bounds.size.y, gbc.bounds.size.z));
    }

    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(gbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(gbc.bounds.size.x * range, gbc.bounds.size.y, gbc.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
    void Update()
    {
        LookAtPlayer();
        if (PlayerInSight()) 
        {

            Vector2 target = new Vector2(player.position.x, grb.position.y);
            Vector2 newPos = Vector2.MoveTowards(grb.position, target, speed * Time.fixedDeltaTime);
            grb.MovePosition(newPos);

        }
       

    }
    public void LookAtPlayer()
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > playerTo.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < playerTo.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
}
