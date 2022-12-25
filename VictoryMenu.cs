using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryMenu : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] GameObject VictoryM;
    public LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
   

    
    void Update()
    {
        if (PlayerInSight())
        {
            VictoryM.SetActive(true);
            Debug.Log("X");
            
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private bool PlayerInSight()

    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
    
}
