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

       player = GameObject.FindGameObjectWithTag("Hero").transform;
       rb = animator.GetComponent<Rigidbody2D>();
       bt = animator.GetComponent<bossToPlayer>();
    
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bt.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
    
   
    

