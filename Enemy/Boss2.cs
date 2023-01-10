using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    // Variables for the boss's rigidbody, box collider, and animator
    public Rigidbody2D wrb;
    public BoxCollider2D wbc;
    public Animator wanim;
    Transform player;
    public BossHP bHP;
    // Variable for the boss's fireball attack
    public FirepointFireBall ffb;
    public HealthBar healthBar;
    // Variables for the boss's stats
    [Header("Boss Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float speedE;
    public int health;
    int currentHealth;
    [SerializeField] private float damage;
    public static bool isAlive = true;
    private int count = 0;

    // Variables for determining if the player is within range and in the boss's line of sight
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask playerLayer;
    // Variables for determining the boss's state
    private float distane;
    private float distane2;
    private float distane3;
    public static bool isEnrged = false;
    public static bool isEnraged1 = false;
    public static bool isEnraged2 = false;


    public Transform playerTo;

    public  bool isFlipped = false;

    private bool normalMovement = true;
    Transform Stage2Point;
    Transform placeBeforeEnraged;

    void Start()
    {
        // Initialize the rigidbody, box collider, and animator components
        wrb = GetComponent<Rigidbody2D>();
        wbc = GetComponent<BoxCollider2D>();
        wanim = GetComponent<Animator>();
        // Initialize the player character
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        // Initialize the boss's health bar
        bHP.MaxHP(health);
        currentHealth = health;
        // Initialize the point in the stage that the boss will move towards
        Stage2Point = GameObject.Find("Stage2Point").GetComponent<Transform>();
        placeBeforeEnraged = GameObject.Find("fallPoint").GetComponent<Transform>();


    }

    // Decrease the boss's health when it takes damage
    public void TakeDamageW(int damage)
    {
        currentHealth -= damage;

        bHP.SetHelth(currentHealth);
        // Check if the boss's health is below certain threshold, if so, change its behavior
        if (currentHealth < 1000)
        {          
            //isEnrged = true;
            normalMovement = false;
        }
        if (currentHealth < 500)
        {
            normalMovement = true;
            isEnraged1 = true;
        }

        if (currentHealth <= 0)
        {
           isAlive = false;
           Die();
           wrb.constraints = RigidbodyConstraints2D.FreezeAll;
           

        }
    }

    void Update()
    {
        // Calculate the distance between the boss and a point in the stage
        distane2 = Vector2.Distance(Stage2Point.position, wrb.position);
        // Calculate the distance between the boss and a point in the stage
        distane3 = Vector2.Distance(placeBeforeEnraged.position, wrb.position);
        // Check if the boss is at the Stage2Point
        if (distane2 < 1f) { isEnrged = true; }
        if (distane2 > 10f) { isEnrged = false; }
        // Check if the boss is alive
        if (isAlive)
         LookAtPlayer();
        {   distane = Vector2.Distance(player.position, wrb.position);

            if (normalMovement == true)
            {
                if (isEnraged1 == false) {
                if (distane > 200f)
                {
                    if (isEnraged1 == false)
                    {
                        Vector2 target = new Vector2(player.position.x, wrb.position.y);
                        Vector2 newPos = Vector2.MoveTowards(wrb.position, target, speed * Time.fixedDeltaTime);
                        wrb.MovePosition(newPos);
                    }
                }
                        if (PlayerInSight())
                        {
                            // Move the boss towards the player and trigger an attack animation
                            Vector2 target = new Vector2(wrb.position.x, wrb.position.y);
                            Vector2 newPos = Vector2.MoveTowards(wrb.position, target, speed * Time.fixedDeltaTime);
                            wrb.MovePosition(newPos);
                            wanim.SetTrigger("Attack");
                        }

                        if (!PlayerInSight())
                        {

                            wanim.SetTrigger("Noone");
                        }               
                }
                else if (isEnraged1 == true)
                {
                    // Move the boss towards the Point
                    Vector2 target1 = new Vector2(placeBeforeEnraged.position.x, placeBeforeEnraged.position.y);
                    Vector2 newPos1 = Vector2.MoveTowards(wrb.position, target1, speedE * Time.fixedDeltaTime);
                    wrb.MovePosition(newPos1); 
                }
                if (distane3 <= 1f)
                {
                    isEnraged2 = true;
                }
            }
            if (normalMovement == false) 
            {
                // Move the boss towards the Stage2Point and trigger a "Noone" animation
                Vector2 target1 = new Vector2(Stage2Point.position.x, Stage2Point.position.y);
                Vector2 newPos1 = Vector2.MoveTowards(wrb.position, target1, speedE * Time.fixedDeltaTime);
                wrb.MovePosition(newPos1);
              
                wanim.SetTrigger("Noone");
            }
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
        // Cast a box-shaped ray and check if it hits a collider on the player layer
        RaycastHit2D hit = Physics2D.BoxCast(wbc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(wbc.bounds.size.x * range, wbc.bounds.size.y, wbc.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        // Return true if the ray hit a collider, false otherwise
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
        //Create a Vector3 variable to store the flipped scale
        Vector3 flipped = transform.localScale;
        //Flip the object on the Z-axis
        flipped.z *= -1f;
        // Check if the object's x position is less than the player's x position and if the object is currently flipped
        if (transform.position.x < playerTo.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        // Check if the object's x position is greater than the player's x position and if the object is not flipped
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
