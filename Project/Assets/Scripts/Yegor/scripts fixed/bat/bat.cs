using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    #region Public Variables
    public GameObject rightCheck, roofCheck, groundCheck;
    public LayerMask groundLayer;
    public LayerMask wall;
    public float speed;
    public float circleRadius;
    public float dirX = 1;
    public float dirY = 1;
    public int health = 100;
    #endregion
    #region Private Variables
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool groundTouch, roofTouch, rightTouch;
    public Animator anim;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Fly", true);
        rb.velocity = new Vector2(dirX, dirY) * speed * Time.deltaTime;
        HitDetection();
    }
    void HitDetection() //checking for hit
    {
        rightTouch = Physics2D.OverlapCircle(rightCheck.transform.position, circleRadius, groundLayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, circleRadius, groundLayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        HitLogic();
    }
    void HitLogic()
    {
        if (rightTouch && facingRight)
        {
            Flip();
        }
        else if (rightTouch && !facingRight)
        {
            Flip();
        }
        if (roofTouch)
        {
            dirY = -0.25f;
        }
        else if (groundTouch)
        {
            dirY = 0.25f;
        }
        void Flip() //animation flip
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
            dirX = -dirX;
        }
    }
    void OnDrawGizmosSelected() //gizmos
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(roofCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);

    }
    /*
        void TakeDamage(int damage)
        {
            anim.SetBool("Hurt", true);

            health -= damage;

            if (health <= 0)
            {

                Die();
            }
        }
        */
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
           
        }
        else if (other.gameObject.tag == "PlayerProjectile")
        {
            anim.SetBool("Attack", false);
            Die();
        }
    }
    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetBool("Death", true);
        Destroy(gameObject);

    }
}