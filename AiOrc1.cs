using UnityEngine;
using System.Collections;

public class AiOrc1 : MonoBehaviour
    {
    public Transform player;
    private Rigidbody2D rb;
   

    void Start()
    {
      rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        

    }

}