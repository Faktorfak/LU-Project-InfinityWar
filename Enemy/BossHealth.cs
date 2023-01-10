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
        // Update the health in the BossHP script
        bHP.SetHelth(currentHealth);

        bHP.SetHelth(currentHealth);

        if (currentHealth < 200)
        {
            // Set the boss to enraged state
            bossIsEnraged = true;
        }

        if (currentHealth <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        // Trigger the "Dead" animation
        anim.SetTrigger("Dead");
        bossIsAlive = false;

    }
}
