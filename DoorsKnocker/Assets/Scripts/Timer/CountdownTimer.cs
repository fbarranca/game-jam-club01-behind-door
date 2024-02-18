using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 1f;

    public Timer gameTimer;
    private bool isInputEnabled = false;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1f); // Wait for a short delay before starting countdown

        // "3"
        countdownText.text = "3";
        yield return new WaitForSeconds(countdownDuration);

        // "2"
        countdownText.text = "2";
        yield return new WaitForSeconds(countdownDuration);

        // "1"
        countdownText.text = "1";
        yield return new WaitForSeconds(countdownDuration);

        // "Go!"
        countdownText.text = "Go!";
        yield return new WaitForSeconds(countdownDuration);

        // Hide the countdown text
        countdownText.gameObject.SetActive(false);

        isInputEnabled = true;

        // Start the main timer
        gameTimer.StartTimer();
    }

    public bool IsInputEnabled()
    { 
        return isInputEnabled;
    }
}
