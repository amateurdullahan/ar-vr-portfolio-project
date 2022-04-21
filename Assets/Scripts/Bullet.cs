using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "Enemy")
        {
            var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            damage = (5 * get.level);
            hitInfo.gameObject.SendMessage("TakeDamage", damage);
        }

        Destroy(gameObject);
    }
}
