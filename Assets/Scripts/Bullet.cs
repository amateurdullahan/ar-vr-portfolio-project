using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public PlayerStats player;

    void Start()
    {
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        player = get;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        damage = player.damage;
        if (hitInfo.gameObject.tag == "Enemy")
        {
            hitInfo.gameObject.SendMessage("TakeDamage", damage);
        }

        Destroy(gameObject);
    }
}
