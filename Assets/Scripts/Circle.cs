using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int damage = 1;
    private int counter;

    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter += 1;
    }

    void OnTriggerStay2D(Collider2D triggerInfo)
    {
        
        if (triggerInfo.gameObject.tag == "Enemy")
        {
            if (counter >= 50)
            {
                triggerInfo.gameObject.SendMessage("TakeDamage", damage);
                counter = 0;
            }
        }
    }
}
