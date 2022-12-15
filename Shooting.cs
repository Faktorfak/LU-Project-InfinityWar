using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectilePrefab;

    void Update()
    {
        
    }

    public void Shoot() 
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
