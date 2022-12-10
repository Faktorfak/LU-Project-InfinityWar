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
        anim = GetComponent<Animator>();
        currentHealth = health;
        initScale = transform.localScale;
        
    }

    
    void Update()
    {
        if (alive == true)
        {

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

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        

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
           
            healthBar.Damage(damage);
            
        }
    
    }


    private void MoveInDirection(int _direction)
    {

        idleTimer = 0;
        anim.SetBool("run", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }


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
