using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BarrelEnd;
    public SpriteRenderer sprite;

    public float countdowntimer = 1f;
    public float resettimer = 1f;

    //public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        //fireRate = 0.5f;
        //nextFire = Time.time;
        sprite.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfTimeToFire ();
        countdowntimer -= Time.deltaTime;
        if(countdowntimer < 0)
        {
            GameObject Projectile = Instantiate(bullet, BarrelEnd.transform.position, transform.rotation);
            Projectile.GetComponent<Rigidbody2D>().AddForce(-transform.right * 0.2f);
            countdowntimer = resettimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Energy")
        {
            Death();
        }
        
    }

    public void Death()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
