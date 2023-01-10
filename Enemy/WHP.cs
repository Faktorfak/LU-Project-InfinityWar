using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizzardHP : MonoBehaviour
{   // Reference to the UI slider component that will display the wizard's health
    public Slider WHP;


    public void MaxWHP(int health)
    {
        WHP.maxValue = health;
        // Set the current value of the health slider to the maximum value
        WHP.value = health;
    }
    // Method to set the current value of the health slider
    public void SetWHelth(int health)
    {
        WHP.value = health;
    }


}