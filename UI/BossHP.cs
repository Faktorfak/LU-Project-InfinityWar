using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public Slider HP;//Reference to a UI Slider component, this will be used to display the boss's health.
                   
    //Method to set the maximum health of the boss and the starting health
    public void MaxHP(int health) 
    {
        HP.maxValue = health;//Sets the maximum value of the health bar to the given health value
        HP.value = health;//Sets the current value of the health bar to the maximum value

    }
    public void SetHelth(int health) 
    {
        HP.value = health; ;//Sets the current value of the health bar to the given health value
    }
}

   

