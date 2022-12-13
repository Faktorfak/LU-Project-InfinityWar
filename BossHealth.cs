using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    int currentHealth;
    private Animator anim;
    public static bool bossIsAlive = true;
    public static bool bossIsEnraged = false;
    public BossHP bHP;
    private void Start()
    {
        currentHealth = health;
        anim = GetComponent<Animator>();
        bHP.MaxHP(health);

    }

    public void TakeDamageB(int damage)
    {
        currentHealth -= damage;
       
        bHP.SetHelth(currentHealth);

        if (currentHealth < 200)
        {
            bossIsEnraged = true;
        }

        if (currentHealth <= 0)
        {
            Die();

        }
    }
    void Die()
    {

        anim.SetTrigger("Dead");
        

    }
}
