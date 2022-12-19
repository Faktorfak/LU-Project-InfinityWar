using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizzardHP : MonoBehaviour
{
    public Slider WHP;


    public void MaxWHP(int health)
    {
        WHP.maxValue = health;
        WHP.value = health;
    }
    public void SetWHelth(int health)
    {
        WHP.value = health;
    }


}