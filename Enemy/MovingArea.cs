using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArea : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    [SerializeField] private float range;  
    [SerializeField] private float colliderDistance;
    public LayerMask playerLayer;
    public static bool isInArea = false; 
    void Start()
    {
        
    }
    void Update()
    {
        if (PlayerInSightArea()) { 
            
            isInArea = true;
        }
        if (!PlayerInSightArea())
        {
           
            isInArea = false;
        }
    }
    private void OnDrawGizmos()// implementation of gizmos to visualize the area in editor
    {
         Gizmos.color = Color.red;
         Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z));

    }
    public bool PlayerInSightArea()

    {
        // Cast a box-shaped ray and check if it hits a collider on the player layer
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        // Return true if the ray hit a collider, false otherwise
        return hit.collider != null;
    }

}
