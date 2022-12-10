using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    int currentHealth;
    private Animator anim;
    public bool bossIsAlive = true;
    public static bool bossIsEnraged = false;
    private void Start()
    {
        currentHealth = health;
        anim = GetComponent<Animator>();
    }

    public void TakeDamageB(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth < 100)
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
