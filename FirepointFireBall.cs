using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointFireBall : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectilePrefab;

    void Update()
    {

    }

    public void ShootFB()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
    }
}
