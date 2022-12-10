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
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        if (BossHealth.bossIsEnraged == false)
        {
            Collider2D colinfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colinfo != null)
            {
                healthBar.Damage(attackDamage);

            }
        }

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
