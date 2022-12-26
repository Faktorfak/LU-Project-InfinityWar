using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 30f;
    public int attackDamage = 40;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D collider1;
    private float direction;

    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private int score;
    public Text scoreText;
    public Text scoreText1;
    public Text finalScoreText;
    public HealthBar healthBar;

    private Animator heroAnimation;

    public static int lives = 3;
    public Text livesText;
    private int counter = 0;
    public bool IsDead = false;

    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public LayerMask rangeEnemyLayers;
    public LayerMask wizzardEnemyLayer;
    public LayerMask goblinLayers;
    public LayerMask shroomLayers;
    public LayerMask flyingEyesLayers;
    public Transform AttackPoint;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        respawnPoint = transform.position;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: x" + lives;
        scoreText1.text = "Score: " + score;
        heroAnimation = GetComponent<Animator>();
       

    }


   
    
    private void Jump() {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    
    }


   

   void Update()
    {
        finalScoreText.text = "Final score: " + score;
        livesText.text = "Lives: x" + lives;
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

        if (IsDead) {

            rb.velocity = new Vector2(0, rb.velocity.y);

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
        if (lives == 0) {

            scoreText1.text = "Score: " + score;

        }
        if (Input.GetMouseButtonDown(0)) 
        {
            Attack();
        }
           
    }


    void Attack() 
    {
        heroAnimation.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, range, enemyLayers);
        Collider2D[] hitBosses = Physics2D.OverlapCircleAll(AttackPoint.position, range, bossLayers);
        Collider2D[] hitRangeEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, range, rangeEnemyLayers);
        Collider2D[] hitWizzardeEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, range, wizzardEnemyLayer);
        Collider2D[] hitGoblins = Physics2D.OverlapCircleAll(AttackPoint.position, range, goblinLayers);
        Collider2D[] hitShrooms = Physics2D.OverlapCircleAll(AttackPoint.position, range, shroomLayers);
        Collider2D[] hitFlyingEyes = Physics2D.OverlapCircleAll(AttackPoint.position, range, flyingEyesLayers);

        foreach (Collider2D enemy in hitEnemies) 
        
        {
            enemy.GetComponent<MeleEnemy>().TakeDamage(attackDamage);
            enemy.GetComponent<RangeEnemy>().TakeDamageR(attackDamage);
           // enemy.GetComponent<Goblin>().TakeDamageG(attackDamage);
        }
        foreach (Collider2D boss in hitBosses)

        {
            boss.GetComponent<BossHealth>().TakeDamageB(attackDamage);
            
        }
        foreach (Collider2D enemyR in hitRangeEnemies)

        {
            enemyR.GetComponent<RangeEnemy>().TakeDamageR(attackDamage);
        }
        foreach (Collider2D bossW in hitWizzardeEnemies)

        {
            bossW.GetComponent<Boss2>().TakeDamageW(attackDamage);
           
        }
        foreach (Collider2D goblin in hitGoblins)

        {
            goblin.GetComponent<Goblin>().TakeDamageG(attackDamage);

        }
        foreach (Collider2D shroom in hitShrooms)

        {
            shroom.GetComponent<Shroom>().TakeDamageS(attackDamage);

        }
        foreach (Collider2D flyingEye in hitFlyingEyes)

        {
            flyingEye.GetComponent<FlyingEye>().TakeDamageF(attackDamage);

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
        counter = 0;
    }

    IEnumerator WFall()
    {
        yield return new WaitForSeconds(1);
        transform.position = respawnPoint;
        lives--;
        healthBar.Heal(1f);
        livesText.text = "Lives: x" + lives;
        counter = 0;
    }



    private void OnTriggerEnter2D(Collider2D collison) 
    {
        if (collison.tag == "FallDetector")
        {
            StartCoroutine(WFall());
        }
        else if (collison.tag == "Diamond")
        {

            score += 100;
            scoreText.text = "Score: " + score;
            //Debug.Log(score);
            //collison.gameObject.SetActive(false);

        }
        else if (collison.tag == "CheckPoint")
        {
            respawnPoint = transform.position;

        }
        else if (collison.tag == "Firstaid")
        {
            healthBar.Heal(0.1f);
           
        }
        else if (collison.tag == "Heart")
        {
            lives++;
            
        }
        else if (collison.tag == "NextLevel")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (collison.tag == "b1")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (collison.tag == "2")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (collison.tag == "b2")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        else if (collison.tag == "3")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spikes") 
        {
            healthBar.Damage(0.002f);
            
        }
        if (collision.tag == "FIRE")
        {
            healthBar.Damage(0.002f);

        }
    }

    public void Die() {

        heroAnimation.SetTrigger("Death");
    
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;


        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AttackPoint.position, range);
    }


}
