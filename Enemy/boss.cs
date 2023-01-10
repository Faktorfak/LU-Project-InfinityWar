using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : StateMachineBehaviour
{
	Transform player;
    Rigidbody2D rb;
   
   
    [Header("Edges")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] public float speed;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    bossToPlayer bt;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        // getting the reference of player's transform component
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        // getting the reference of the boss's rigidbody component
        rb = animator.GetComponent<Rigidbody2D>();
        // getting the reference of the custom component on boss
        bt = animator.GetComponent<bossToPlayer>();
    
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bt.LookAtPlayer();
        // creating the target position where the boss should move
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        // calculating the new position of the boss
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        // moving the boss to new position
        rb.MovePosition(newPos);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
    
   
    

