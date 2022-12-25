using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
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
           // Debug.Log("AREA"); 
            isInArea = true;
        }
      
    }
    private void OnDrawGizmos()
    {
         Gizmos.color = Color.red;
         Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z));

    }
    public bool PlayerInSightArea()

    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z), 0, Vector2.left, 0, playerLayer);
       

        return hit.collider != null;
    }

}
