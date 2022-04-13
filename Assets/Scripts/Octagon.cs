using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octagon : MonoBehaviour
{
    public float enemySpeed;
    public int rateOfFire;
    private int counter;
    private Enemy enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rateOfFire = 100;
        counter = 0;
        enemySpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter += 1;
    }

    //ontriggerenter get speed
    //ontriggerstay change speed
    //ontriggerexit change back speed???
    
    void OnTriggerEnter2D(Collider2D triggerInfo)
    {
        
        if (triggerInfo.gameObject.tag == "Enemy")
        {
            enemy = triggerInfo.GetComponent<Enemy>();
            enemySpeed = enemy.moveSpeed;
        }
    }

    void OnTriggerStay2D(Collider2D triggerInfo)
    {
        enemy.moveSpeed = 0;
    }
    
    void OnTriggerExit2D(Collider2D triggerInfo)
    {
        enemy.moveSpeed = enemySpeed;
    }

}
