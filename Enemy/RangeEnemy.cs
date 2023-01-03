using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float attackColldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float coldowTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private LayerMask playerLayer;
    

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
    public Shooting shoot;
    public static int shootingSide;

    public Transform hero;


    private bool alive = true;


    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
        initScale = transform.localScale;
        shootingSide = 1;

    }


    void Update()
    {
        //Debug.Log(shootingSide);
        if (alive == true)
        {
            if (!PlayerInSight())
            {

                if (movingLeft)
                {
                    if (enemy.position.x >= leftEdge.position.x)
                    {
                        MoveInDirection(-1);
                      //  shootingSide = -1;
                    }
                    else
                    {
                        DirectionChange();
                    }
                }
                else
                {
                    if (enemy.position.x <= rightEdge.position.x)
                    {

                        MoveInDirection(1);
                      //  shootingSide = 1;
                    }
                    else
                    {
                        DirectionChange();
                    }
                }

            }


            coldowTimer += Time.deltaTime;


            if (PlayerInSight())
            {

                if (enemy.position.x > hero.position.x)
                {
                   
                    shootingSide = -1;
                }
                if (enemy.position.x <= hero.position.x)
                {

                    
                    shootingSide = 1;
                }
                anim.SetBool("run", false);
                if (coldowTimer >= attackColldown)
                {
                    coldowTimer = 0;
                    //Wait();
                    anim.SetTrigger("attack");


                }

            }
        }
    }

    public void TakeDamageR(int damage)
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        anim.SetTrigger("attack");

    }
    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z));
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
