using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("1");
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("hit");
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
