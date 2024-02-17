using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Door[] doors;
    private bool roundCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        doors = FindObjectsOfType<Door>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (AllDoorsDeactivated() && !roundCompleted)
        {
            Debug.Log("All doors deactivated! Round Complete!");
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
}
