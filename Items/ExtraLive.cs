using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLive : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
       
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
