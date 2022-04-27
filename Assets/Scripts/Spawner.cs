using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemy;
    public int counter;
    private int wave;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        wave = 1;
        Instantiate(enemy, new Vector3(spawnPoint.position.x + GetModifier(), spawnPoint.position.y + GetModifier()), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter += 1;
        if (counter % 500 == 0)
        {
            WaveSpawn();
            wave++;
        }
    }

    void WaveSpawn()
    {
        for (int i = 0; i < wave; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(enemy, new Vector3(spawnPoint.position.x + GetModifier(), spawnPoint.position.y + GetModifier()), Quaternion.identity);
            }
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
