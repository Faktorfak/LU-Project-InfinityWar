using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointFireBall : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectilePrefab;

 

    public void ShootFB()
    {
        // Instantiate a projectile prefab at the position and rotation of the firePoint object
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
