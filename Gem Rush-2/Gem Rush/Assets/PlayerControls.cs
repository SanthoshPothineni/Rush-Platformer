using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public Transform playerPos;
    //public GameObject respawnPos;

    public float speed = 7.0f;
    public float jumpVelocity = 500f;

    public bool isGrounded = true;
    public bool facingRight = true;
    public bool canMove = true;

    public Transform FirePoint;

    public GameObject door;

    public GameObject enemy;

    public float dashspeed;
    private float dashtime;
    public float startDashTime;
    private int direction;
    public int DashCharge;
    public float delaytime = .45f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GetComponent<Transform>();
       // respawnPos = GameObject.FindGameObjectWithTag("Respawn");
        door = GameObject.FindGameObjectWithTag("Door");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        dashtime = startDashTime;



    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (Input.GetKey(KeyCode.D))
            {
                sprite.flipX = false;
                anim.SetBool("isWalking", true);
                rb.velocity += Vector2.right * speed;
                facingRight = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                sprite.flipX = true;
                anim.SetBool("isWalking", true);
                rb.velocity += Vector2.left * speed;
                facingRight = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                anim.SetBool("isJumping", true);
                isGrounded = false;
                rb.AddForce(Vector2.up * jumpVelocity);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Tutorial");
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("isWalking", false);
            }

            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !(DashCharge <= 0))
                {

                    direction = 1;
                    DashCharge -= 1;
                anim.SetBool("isDashing", true);
            }

                else if (Input.GetKeyDown(KeyCode.RightArrow) && !(DashCharge <= 0))
                {

                    direction = 2;
                    DashCharge -= 1;
                anim.SetBool("isDashing", true);
            }

                else if (Input.GetKeyDown(KeyCode.UpArrow) && !(DashCharge <= 0))
                {

                    direction = 3;
                    DashCharge -= 1;
                anim.SetBool("isdashingup", true);
            }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {

                    direction = 4;
                anim.SetBool("isdashingup", true);
            }
            }

            else
            {
                if (dashtime <= 0)
                {
                    direction = 0;
                    dashtime = startDashTime;
                    rb.velocity = Vector2.zero;

                }

                else
                {
                    dashtime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        sprite.flipX = true;
                        rb.velocity = Vector2.left * dashspeed;
                        //anim.SetBool("isDashing", true);

                    }

                    else if (direction == 2)
                    {
                        sprite.flipX = false;
                        rb.velocity = Vector2.right * dashspeed;
                        //anim.SetBool("isDashing", true);
                    }

                    else if (direction == 3)
                    {
                        rb.velocity = Vector2.up * dashspeed;
                        
                    }

                    else if (direction == 4)
                    {
                        rb.velocity = Vector2.down * dashspeed;
 
                    }

                }
                anim.SetBool("isDashing", false);
            anim.SetBool("isdashingup", false);

        }
 
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
            DashCharge = 2;

        }

        if (col.gameObject.tag == "Enemy")
        {
            enabled = false;
            anim.SetBool("isdead", true);
            Invoke("hardRestartGame", delaytime);
        }

        if (col.gameObject.tag == "Spike")
        {
            enabled = false;
            anim.SetBool("isdead", true);
            Invoke("hardRestartGame", delaytime);
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
        }

       

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Finish")
        {
            //SceneManager.LoadScene("lv2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            anim.SetBool("isdead", true);
            Invoke("hardRestartGame", delaytime);
        }

    }
    

    void hardRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


