using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private bool isTimerRunning;
    [SerializeField] private TMP_Text timerText;
    
    private void Start() => isTimerRunning = true;

    private void Update() => TimerCount();

    private void TimerCount()
    {
        if(isTimerRunning && time >= 0)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
