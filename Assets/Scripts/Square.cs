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
    public int sides = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
}

