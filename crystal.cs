using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{

    private AudioSource audioSource;
    private GameObject hero;
    public AudioClip aidioClip;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        audioSource = hero.GetComponent<AudioSource>();      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero") 
        {
            audioSource.PlayOneShot(aidioClip);
            
        }
    }
}
