using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public Rigidbody2D wrb;
    public BoxCollider2D wbc;
    public Animator wanim;
    Transform player;
    public BossHP bHP;
    public FirepointFireBall ffb;
    public HealthBar healthBar;

    [Header("Boss Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float speedE;
    public int health;
    int currentHealth;
    [SerializeField] private float damage;
    private bool isAlive = true;
    private int count = 0;
  

    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask playerLayer;
    private float distane;
    private float distane2;
    public static bool isEnrged = false;


    public Transform playerTo;

    public bool isFlipped = false;

    private bool normalMovement = true;
    Transform Stage2Point;

    void Start()
    {
        wrb = GetComponent<Rigidbody2D>();
        wbc = GetComponent<BoxCollider2D>();
        wanim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        bHP.MaxHP(health);
        currentHealth = health;
        Stage2Point = GameObject.Find("Stage2Point").GetComponent<Transform>();

    }

    public void TakeDamageW(int damage)
    {
        currentHealth -= damage;

        bHP.SetHelth(currentHealth);

        if (currentHealth < 500)
        {
            
            //isEnrged = true;
            normalMovement = false;
           

        }

        if (currentHealth <= 0)
        {
           isAlive = false;
           Die();
            wrb.constraints = RigidbodyConstraints2D.FreezeAll;
            isEnrged = false;

        }
    }

    void Update()
    {
        distane2 = Vector2.Distance(Stage2Point.position, wrb.position);
        Debug.Log(distane2);

        if (distane2 < 1f) { isEnrged = true; } 


        LookAtPlayer();
        if (isAlive)
        {   distane = Vector2.Distance(player.position, wrb.position);

            if (normalMovement == true)
            {
                if (distane > 200f)
                {
                    Vector2 target = new Vector2(player.position.x, wrb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(wrb.position, target, speed * Time.fixedDeltaTime);
                    wrb.MovePosition(newPos);
                }


                if (PlayerInSight())
                {
                    wanim.SetTrigger("Attack");
                }

                if (!PlayerInSight())
                {

                    wanim.SetTrigger("Noone");
                }
            }
            if (normalMovement == false) 
            {
                Vector2 target1 = new Vector2(Stage2Point.position.x, Stage2Point.position.y);
                Vector2 newPos1 = Vector2.MoveTowards(wrb.position, target1, speedE * Time.fixedDeltaTime);
                wrb.MovePosition(newPos1);
              
                wanim.SetTrigger("Noone");
            }


        }
        if (isAlive == false)
        {
            //
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(wbc.bounds.size.x * range, wbc.bounds.size.y, wbc.bounds.size.z));
    }

    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(wbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(wbc.bounds.size.x * range, wbc.bounds.size.y, wbc.bounds.size.z), 0, Vector2.left, 0, playerLayer);

      

        return hit.collider != null;
    }

    private void DamgePlayer()
    {
        if (PlayerInSight())
        {

            healthBar.Damage(damage);

        }

    }
    public void LookAtPlayer()
    {
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
   
    void Die()
    {

    wanim.SetTrigger("Dead");


    }
   }
