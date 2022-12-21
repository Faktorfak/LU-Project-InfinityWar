using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float rangey;
    [SerializeField] private float colliderDistance;
    [SerializeField] BoxCollider2D bc;
    public LayerMask playerLayer;
    Animator anim;
    public HealthBar healthBar;
    private float damage = 0.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LandMine.isInAreaE == true)
        {
            anim.SetTrigger("Explosion");
            if (PlayerInSightArea())
            {


            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(bc.bounds.size.x * range, bc.bounds.size.y * rangey, bc.bounds.size.z));

    }
    public bool PlayerInSightArea()

    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(bc.bounds.size.x * range, bc.bounds.size.y, bc.bounds.size.z), 0, Vector2.left, 0, playerLayer);


        return hit.collider != null;
    }
    private void DamgePlayer()
    {
        if (LandMine.isInAreaE)
        {

            healthBar.Damage(damage);

        }

    }
}
