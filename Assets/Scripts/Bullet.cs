using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerStats player;

    void Start()
    {
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        player = get;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            hitInfo.gameObject.SendMessage("TakeDamage", player.damage);
        }

        Destroy(gameObject);
    }
}
