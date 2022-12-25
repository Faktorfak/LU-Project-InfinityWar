using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class crystal : MonoBehaviour
{

    [SerializeField] public AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
   
    private GameObject hero;
    
   
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") 
        {
            Debug.Log("Sound");
            audioSource.Play();
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
            
    }
        
}
