using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : MonoBehaviour
{

    [SerializeField]private float attackColldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float coldowTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private LayerMask playerLayer;
    public HealthBar healthBar;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
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
}
