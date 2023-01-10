using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour

{
    private RectTransform bar;
    private Image barImage;
    private Animator animator;
    private Movement movement;

    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        SetSize(Health.totalHealth);
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

  

    public void Damage(float damage) {
        // if total health is greater than or equal to 0 after subtracting the damage
        if ((Health.totalHealth -= damage) >= 0f)
        {
            // subtract damage from total health
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
        }
        if (Health.totalHealth < 0.6f)
        {
            barImage.color = Color.yellow;
        }
        if (Health.totalHealth < 0.3f) 
        {
            barImage.color = Color.red;       
        }
        if (Health.totalHealth > 0.6f)
        {
            barImage.color = Color.green;
        }

        // trigger the "hurt" animation
        animator.SetTrigger("hurt");
        // call the SetSize function and pass totalHealth as an argument
        SetSize(Health.totalHealth);
    }

    public void Heal(float heal)
    {
        // if total health is less than or equal to 1 after adding the heal amount
        if ((Health.totalHealth += heal) <= 1f)
        {
            Health.totalHealth =1f;
        }
        else if ((Health.totalHealth) > 1f) {

            Health.totalHealth = 1f;
        }
        else
        {
            Health.totalHealth = 1f;
        }
        if (Health.totalHealth < 0.6f)
        {
            barImage.color = Color.yellow;
        }
        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        if (Health.totalHealth > 0.6f)
        {
            barImage.color = Color.green;
        }

        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 0.1157552f); 
    
    }
   

}
