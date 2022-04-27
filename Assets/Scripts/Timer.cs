using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timerValue = 0f;
    public bool timerStart = false;

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            timerValue += Time.deltaTime;
            float minutes = Mathf.FloorToInt(timerValue / 60);
            float seconds = Mathf.FloorToInt(timerValue % 60);
            float milliseconds = (timerValue % 1) * 100;
            timerText.text = timerValue.ToString("0:00.00");
        }
    }
}