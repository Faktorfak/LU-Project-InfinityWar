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
        // Find the hero game object in the scene with the "Hero" tag
        hero = GameObject.FindGameObjectWithTag("Hero");
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with an object with the "Hero" tag
        if (collision.tag == "Hero") 
        {
            // Play the sound effect
            audioSource.Play();
            // Disable the sprite renderer and box collider components
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
            
    }
        
}
