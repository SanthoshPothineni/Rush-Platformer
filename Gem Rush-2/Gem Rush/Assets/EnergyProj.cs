using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyProj : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        if (playerSprite.flipX == false)
        {
            rb.velocity = transform.right * speed;
        }

        if (playerSprite.flipX == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = -transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
