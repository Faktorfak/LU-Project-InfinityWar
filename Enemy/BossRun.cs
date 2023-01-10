using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;


    [Header("Edges")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] public float speed;
    [SerializeField] public float eSpeed;

    [Header("Stats")]
    public float attackRange = 100f;
    bossToPlayer bt;
    private float test;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Hero").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bt = animator.GetComponent<bossToPlayer>();

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Call the LookAtPlayer method in the bossToPlayer script
        bt.LookAtPlayer();
        if (BossHealth.bossIsEnraged == false)
        {
            // Create a target position for the boss to move towards
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            // Move the boss towards the target position at the specified speed
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        if (BossHealth.bossIsEnraged == true)
        {
            // Create a target position for the boss to move towards
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            // Move the boss towards the target position at the specified speed
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, eSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        test = Vector2.Distance(player.position, rb.position);
       

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {   
            
            animator.SetTrigger("Attack");
           
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
