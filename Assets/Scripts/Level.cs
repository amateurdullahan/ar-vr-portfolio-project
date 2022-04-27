using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public PlayerStats player;
    public Text levelText;
    
    // Start is called before the first frame update
    void Start()
    {
        var get = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        player = get;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + player.level.ToString();
    }
}
