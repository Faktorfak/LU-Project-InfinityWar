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
    private bool alive;

    void Start()
    {
        // Store the initial scale of the enemy
        initScale = enemy.localScale;

    }

    void Update()
    {
     
            if (movingLeft)
            {
            // If the enemy's x position is greater than or equal to the left edge's x position
            if (enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
            // If the enemy's x position is less than or equal to the right edge's x position
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
        // Move the enemy's position based on the specified direction and speed
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }


    private void DirectionChange()
    {
        anim.SetBool("run", false);

        idleTimer += Time.deltaTime;
        // Check if the idle timer is greater than the idle duration
        if (idleTimer > idleDuration) 
        {
            // Change the movingLeft variable to
            movingLeft = !movingLeft;
        }
    }
}
