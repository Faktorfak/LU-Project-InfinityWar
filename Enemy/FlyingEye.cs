using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
   
    Transform player;
    AttackArea aa;
   
    public HealthBar healthBar;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] LayerMask playerLayer;
    [Header("Movement parmeters")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [Header("Health")]
    [SerializeField] private int health;
    private int currentHealth;
    private bool alive = true;
    [SerializeField] public GameObject AttackArea1;

    private bool isFlipped;
    public Transform playerTo;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        currentHealth = health;
    }

    private void DamgePlayer()
    {      
        healthBar.Damage(damage);     
    }

    void Update()
    {
        // Only execute the following code if the enemy is alive
        if (alive)
        {
            LookAtPlayer();
            // Check if the player is within the range of the attack area object
            if (AttackArea1.GetComponent<AttackArea>().isInArea)
            {
                Vector2 target = new Vector2(player.position.x + 35f, player.position.y + 70f);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);

                if (PlayerInSight1())
                {
                   
                    anim.SetTrigger("Attack");
                }
                if (!PlayerInSight1())
                {
                    anim.SetTrigger("Idle");
                }
            }
        }


       

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }
    public bool PlayerInSight1()

    {
        // Cast a box-shaped ray and check if it hits a collider on the player layer
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        // Return true if the ray hit a collider, false otherwise
        return hit.collider != null;
    }
    public void TakeDamageF(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die() 
    {
        alive = false;
        ToPlayer.isAlive = false;
        anim.SetTrigger("Dead");
    }
    
    public void LookAtPlayer()
    {
        //Create a Vector3 variable to store the flipped scale
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < playerTo.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > playerTo.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
