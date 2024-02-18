using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Door[] doors;
    public Transform startRoom;
    private bool roundCompleted = false;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        doors = FindObjectsOfType<Door>();
        timer.onTimerEnd.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (AllDoorsDeactivated() && !roundCompleted)
        {
            Debug.Log("All doors deactivated! Round Complete!");
            roundCompleted = true;
        }
        else if (roundCompleted &&
        Vector2.Distance(Camera.main.transform.position, startRoom.transform.position) < 0.1f)
        {
            roundCompleted = false;
            Debug.Log("Starting new round");
            StartNewRound();
        }
    }

    bool AllDoorsDeactivated()
    {
        foreach (Door door in doors) 
        {
            // If any door's target spot is still active, return false
            if (door.targetSpot.activeSelf)
            {
                return false;
            }
        }
        // If no door's target spot is active, return true
        return true;
    }

    void StartNewRound()
    {
        // Activate all doors
        foreach (Door door in doors)
        {
            door.gameObject.SetActive(true);
            door.targetSpot.SetActive(true);
            door.MoveTargetSpotToRandomPosition();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGameScene");
    }
}
