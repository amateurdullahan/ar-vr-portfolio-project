using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int radius = 1;
    public int damage = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D triggerInfo)
    {
        
        if (triggerInfo.gameObject.tag == "Enemy")
        {
            triggerInfo.gameObject.SendMessage("TakeDamage", damage);
            
        }
    }
}
