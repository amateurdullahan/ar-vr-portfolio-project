using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;
    public int counter;
    
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
        if (counter % 750 == 9)
        {
            WaveSpawn();
        }
    }

    void WaveSpawn()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy, new Vector3(spawnPoint.position.x + GetModifier(), spawnPoint.position.y + GetModifier()), Quaternion.identity);
        }
    }

    float GetModifier()
    {
        float modifier = Random.Range(0f, 1f);
        if (Random.Range(0, 2) > 0)
            return -modifier;
        else
            return modifier;
    }
}
