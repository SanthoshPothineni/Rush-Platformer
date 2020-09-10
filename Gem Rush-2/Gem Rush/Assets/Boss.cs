using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int health = 50;
    public int damage;
    public Slider healthbar;
    public Text Victory;
    public GameObject restartScreen;


    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        restartScreen.SetActive(false);
        Victory.GetComponent<Text>();
        Victory.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health;
        if(isWon)
        {
            Victory.enabled = true;
            restartScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            health -= 1;
        }
    }

    void resetHealth()
    {
        health = 50;
    }

    public bool isWon
    {
        get
        {
            if (health <= 0)
            {
                return true;
            }

            return false;
        }
        
    }
}
