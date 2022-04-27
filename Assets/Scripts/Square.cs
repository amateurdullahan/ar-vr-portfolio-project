using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

    public Transform firePointTop;
    public Transform firePointLeft;
    public Transform firePointRight;
    public Transform firePointBottom;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private int sides = 0;
    public int counter;
    public int rateOfFire;
    //Weapon level
    public int sLevel;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        rateOfFire = 100;
        var getP = GameObject.FindWithTag("Player");
        player = getP;
        sLevel = 1;
    }

   
    void FixedUpdate()
    {
        counter += 1;
        if (counter >= rateOfFire)
        {
            if (sides == 0)
            {
                SquareShoot(firePointTop);
                sides++;
            }
            else if (sides == 1)
            {
                SquareShoot(firePointRight);
                sides++;
            }
            else if (sides == 2)
            {
                SquareShoot(firePointBottom);
                sides++;
            }
            else
            {
                SquareShoot(firePointLeft);
                sides = 0;
            }
            counter = 0;
        }
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        if (get.level > sLevel)
        {
            sLevel = get.level;
            SquareLevel(sLevel);
        }
    }

    void SquareShoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (firePoint == firePointTop)
        {
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (firePoint == firePointRight)
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else if (firePoint == firePointBottom)
        {
            rb.AddForce((firePoint.up * -1) * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce((firePoint.right * -1) * bulletForce, ForceMode2D.Impulse);
        }
    }

    void SquareLevel(int level)
    {
        rateOfFire = rateOfFire - (level * 4);
    }
}

