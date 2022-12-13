using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public Slider HP;


    public void MaxHP(int health) 
    {
        HP.maxValue = health;
        HP.value = health;
    }
    public void SetHelth(int health) 
    {
        HP.value = health;
    }

   
}
