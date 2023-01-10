using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private float attackDamage;

    [SerializeField] private float attackDamageE;
    [SerializeField] public float speed = 5.5f;
    [SerializeField] public float attackRange = 1f;
    public Vector3 attackOffset;
    public LayerMask attackMask;
    public HealthBar healthBar;


    public void BossAtttack()
    {
        // Create a Vector3 to store the attack position
        Vector3 pos = transform.position;
        // Add the attack offset to the x-axis of the position
        pos += transform.right * attackOffset.x;
        // Add the attack offset to the y-axis of the position
        pos += transform.up * attackOffset.y;
        // Check if the boss is not in an enraged state
        if (BossHealth.bossIsEnraged == false)
        {
            // Check for any colliders within the attack range and attackMask
            Collider2D colinfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colinfo != null)
            {
                // Damage by the specified attackDamage
                healthBar.Damage(attackDamage);

            }
        }
        // Check if the boss is in an enraged state
        if (BossHealth.bossIsEnraged == true)
        {
            Collider2D colinfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colinfo != null)
            {
                healthBar.Damage(attackDamageE);

            }
        }




    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    
}
