using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int damage;
    private int counter;
    public int cLevel;

    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        cLevel = 1;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter += 1;
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        if (get.level > cLevel)
        {
            cLevel = get.level;
            CircleLevel(cLevel);
        }
    }

    void OnTriggerStay2D(Collider2D triggerInfo)
    {
        
        if (triggerInfo.gameObject.tag == "Enemy")
        {
            if (counter >= 25)
            {
                triggerInfo.gameObject.SendMessage("TakeDamage", damage);
                counter = 0;
            }
        }
    }

    void CircleLevel(int level)
    {
        damage = damage + (level * 2);
    }
}
