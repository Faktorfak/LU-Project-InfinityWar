using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    Animator animator;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    public LayerMask playerLayer;
    [SerializeField] GameObject VictoryM;
    void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        animator.enabled = false;
    }

    
    void Update()
    {
        // Check if the first boss is not alive
        if (BossHealth.bossIsAlive == false)
        {
            // Enable the box collider, sprite renderer, and animator
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            animator.enabled = true;

            if (PlayerInSight())
            {
                // Show the victory  UI
                VictoryM.SetActive(true);
                // Stop time
               
                Time.timeScale = 0f;
            }
        }
        if(Boss2.isAlive == false)
        {
            // Enable the box collider, sprite renderer, and animator
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            animator.enabled = true;

            if (PlayerInSight())
            {
                // Show the victory  UI
                VictoryM.SetActive(true);
                // Stop time
                Time.timeScale = 0f;
            }
        }

    }
    private void OnDrawGizmos()// implementation of gizmos to visualize the area in editor
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private bool PlayerInSight()

    {
        // Cast a box-shaped ray and check if it hits a collider on the player layer
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        // Return true if the ray hit a collider, false otherwise
        return hit.collider != null;
    }
}
