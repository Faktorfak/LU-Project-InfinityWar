using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 30f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float direction;

    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private int score = 0;
    public Text scoreText;
    public HealthBar healthBar;

    private Animator heroAnimation;

    public static int lives = 3;
    public Text livesText;
    private int counter = 0;
    public bool IsDead = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        respawnPoint = transform.position;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: x" + lives;
        heroAnimation = GetComponent<Animator>();
       

    }


   
    
    private void Jump() {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    
    }


   

   void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);
        
        direction = Input.GetAxis("Horizontal");

        if (!IsDead)
        {

            if (direction > 0f)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                transform.localScale = new Vector2(-65.28873f, 65.28873f);
            }
            else if (direction < 0f)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                transform.localScale = new Vector2(65.28873f, 65.28873f);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }


            if (Input.GetButton("Jump") && isTouchingGround)
            {

                Jump();
            }
        }
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        
        heroAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        heroAnimation.SetBool("OnGround", isTouchingGround);

        if (counter != 1) {

            if (Health.totalHealth == 0f) {

                Die();
                counter++;
                IsDead = true;
                StartCoroutine(Wait());
                
            }
        
        }
           
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(3);
        transform.position = respawnPoint;
        healthBar.Heal(1f);
        IsDead = false;
        heroAnimation.SetTrigger("Alive");
        lives--;
        livesText.text = "Lives: x" + lives;
    }

    IEnumerator WFall()
    {
        yield return new WaitForSeconds(1);
        transform.position = respawnPoint;
        lives--;
        healthBar.Heal(1f);
        livesText.text = "Lives: x" + lives;
    }



    private void OnTriggerEnter2D(Collider2D collison) 
    {
        if (collison.tag == "FallDetector")
        {
            StartCoroutine(WFall());
        }
        else if (collison.tag == "Diamond")
        {

            score += 10;
            scoreText.text = "Score: " + score;
            Debug.Log(score);
            collison.gameObject.SetActive(false);

        }
        else if (collison.tag == "CheckPoint")
        {
            respawnPoint = transform.position;

        }
        else if (collison.tag == "Firstaid")
        {
            healthBar.Heal(0.1f);
            collison.gameObject.SetActive(false);
        }
        else if (collison.tag == "NextLevel") {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spikes") 
        {
            healthBar.Damage(0.002f);
            
        }
    }

    public void Die() {

        heroAnimation.SetTrigger("Death");
    
    }
}
