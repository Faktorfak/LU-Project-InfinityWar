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
    int currentHealth;
    public HealthBar healthBar;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform enemy;
    private bool alive = true;

    [Header("Goblin Stats")]
    [SerializeField]private float range;
    [SerializeField]private float range1;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float colliderDistance1;
    [SerializeField] private float speed;
    [SerializeField] private int health;  
    [SerializeField] private float damage;

   
    MovingArea ma;
    void Start()
    {
        ganim = GetComponent<Animator>();        
        grb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        currentHealth = health;

    }
    private void OnDrawGizmos()
    {
       /* Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(gbc.bounds.size.x * range, gbc.bounds.size.y, gbc.bounds.size.z));*/
       
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(gbc.bounds.center + transform.right * range1 * transform.localScale.x * colliderDistance1,
        new Vector3(gbc.bounds.size.x * range1, gbc.bounds.size.y, gbc.bounds.size.z));
    }

    
    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(gbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(gbc.bounds.size.x * range, gbc.bounds.size.y, gbc.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
    private bool PlayerInSight1()

    {
        RaycastHit2D hit = Physics2D.BoxCast(gbc.bounds.center + transform.right * range1 * transform.localScale.x * colliderDistance1,
         new Vector3(gbc.bounds.size.x * range1, gbc.bounds.size.y, gbc.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
    void Update()
    {
        Debug.Log(currentHealth);

        if (alive)
        {
            LookAtPlayer();
            if (MovingArea.isInArea == true)
            {
                if (!PlayerInSight1())
                {
                    ganim.SetTrigger("Run");
                    Vector2 target = new Vector2(player.position.x, grb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(grb.position, target, speed * Time.fixedDeltaTime);
                    grb.MovePosition(newPos);
                }


            }

            if (!MovingArea.isInArea)
            {
                ganim.SetTrigger("Stay");
            }


            if (PlayerInSight1())
            {

                ganim.SetTrigger("Attack");
            }

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

    public void TakeDamageG(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {           
            Die();           
        }
    }

    private void DamgePlayer()
    {
        if (PlayerInSight())
        {

            healthBar.Damage(damage);

        }

    }

    void Die() 
    {
        alive = false;
        ganim.SetTrigger("Die");
    }
}
