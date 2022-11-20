using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrool : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parmeters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Idle Behavior")]

    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header ("Enemy Animator")]
    [SerializeField] private Animator anim;


    void Start()
    {
        initScale = enemy.localScale;
    }

    void Update()
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

    private void MoveInDirection(int _direction) {

        idleTimer = 0;
        anim.SetBool("run", true);
        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

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
