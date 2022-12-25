using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    Rigidbody rb;
    Animator anim;
    private Vector3 initScale;
    [SerializeField] private Transform enemy;

    [SerializeField] private float speed;
    private bool alive = true;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private bool movingLeft;
    public HealthBar healthBar;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private int health;
    int currentHealth;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;

    [SerializeField] private LayerMask playerLayer;
    void Start()
    {
            
         anim = GetComponent<Animator>();
         initScale = transform.localScale;
            currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
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

            if (PlayerInSight()) 
            {
                healthBar.Damage(damage);
            }

        }

    }

    private void MoveInDirection(int _direction)
    {             
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {

        //Debug.Log("Change");
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }
    void Die()
    {

        anim.SetTrigger("Dead");
        alive = false;

    }
    public void TakeDamageS(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z));
    }
    private void DamgePlayer()
    {
        //healthBar.Damage(damage);                     
    }
    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
}
