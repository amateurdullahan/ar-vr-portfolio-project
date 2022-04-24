using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Triangle : MonoBehaviour
{
    public Transform firePointTop;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public int rateOfFire;
    public int counter;
    public int tLevel;
    

    void Start()
    {
	    counter = 0;
        rateOfFire = 100;
        tLevel = 1;
    }

    void ShootTri()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointTop.position, firePointTop.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointTop.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce((firePointLeft.right * -1) * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce((firePointRight.right) * bulletForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
	    counter += 1;
        if (counter >= rateOfFire)
        {
            ShootTri();
            counter = 0;
        }
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        if (get.level > tLevel)
        {
            tLevel = get.level;
            TriangleLevel(tLevel);
        }
    }

    void TriangleLevel(int level)
    {
        rateOfFire = rateOfFire - (level * 3);
    }
}
