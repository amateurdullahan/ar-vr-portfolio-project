using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float moveSpeed = 2f;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    public int health = 10;
    //public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        var getP = GameObject.FindWithTag("Player");
        player = getP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position);
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }

    void LateUpdate()
    {
        //Correctly orients enemy towards player to the right or left
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (rb.velocity.y < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {            
            Die();
        }
    }

    void Die()
    {
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        get.GainExperience(5);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "Player")
        {
            hitInfo.gameObject.SendMessage("TakeDamage", 5);
        }
    }
}
