using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f;
    public UnityEvent onTimerEnd;
    public TextMeshProUGUI timerText;

    private Coroutine timerCoroutine;

    //void Start()
    //{
    //    StartTimer();
    //}

    public void StartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(TimerCountdown());
    }

    IEnumerator TimerCountdown()
    {
        float currentTime = totalTime;

        while (currentTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            currentTime -= 1f;
            // Update UI or perform other actions based on remaining time
            UpdateTimerText(currentTime);
        }

        // Timer has ended
        onTimerEnd.Invoke();
    }

    public void ResetTimer()
    {
        StopTimer();
        StartTimer();
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    void UpdateTimerText(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timerString = string.Format("{0}:{1:00}", minutes, seconds);
        timerText.text = timerString; // Update the Text component with the formatted time string
    }
}
