using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField]private float attackColldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float coldowTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private LayerMask playerLayer;
    public HealthBar healthBar;

    private Animator anim;
    int currentHealth;
    //patrool points
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parmeters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]

    [SerializeField] private float idleDuration;
    private float idleTimer;

  
    
    private bool alive = true;


    void Start()
    {
        //getting enemy object values
        anim = GetComponent<Animator>();
        currentHealth = health;
        initScale = transform.localScale;
        
    }

    
    void Update()
    {
        if (alive == true)
        {
            //changing direction after point
            if (movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)

                    MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }

        }

        coldowTimer += Time.deltaTime;


        if (PlayerInSight())
        { 
          if(coldowTimer >= attackColldown)
        {
                coldowTimer = 0;
                anim.SetTrigger("attack");       
        }
        
        }

    }
    // player damage
    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        
        //die if health < 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        anim.SetTrigger("Dead");
        alive = false;
        
    }
    //player trigger
    private bool PlayerInSight() 
    
    {
        RaycastHit2D hit = Physics2D.BoxCast(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z), 0, Vector2.left, 0,playerLayer);
     
      
      
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z));
    }

    private void DamgePlayer()
    {
        if (PlayerInSight()) {
           //damaging player 
            healthBar.Damage(damage);
            
        }
    
    }


    private void MoveInDirection(int _direction)
    {

        idleTimer = 0;
        anim.SetBool("run", true);
        //moving enemy object
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    //enemy changes dirrection
    private void DirectionChange()
    {
        anim.SetBool("run", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

}
