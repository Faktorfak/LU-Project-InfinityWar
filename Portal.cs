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
        if (BossHealth.bossIsAlive == false)
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            animator.enabled = true;

            if (PlayerInSight())
            {
                VictoryM.SetActive(true);
                Debug.Log("X");

            }
        }
        if(Boss2.isAlive == false)
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;
            animator.enabled = true;

            if (PlayerInSight())
            {
                VictoryM.SetActive(true);
                Debug.Log("X");

            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
}
