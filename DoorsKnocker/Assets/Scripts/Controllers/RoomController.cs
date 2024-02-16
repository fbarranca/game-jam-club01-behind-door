using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController instance;
    public Transform[] roomPositions;

    private int currentRoomIndex = 0;

    void Awake()
    {
        // Ensure only one instance of RoomController exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate RoomController found. Destroying the duplicate.");
            Destroy(gameObject);
        }
    }


    public Vector3 GetCurrentRoomPosition()
    {
        return roomPositions[currentRoomIndex].position;
    }

    public Vector3 MoveToRightRoom()
    {
        currentRoomIndex++;

        if (currentRoomIndex >= roomPositions.Length)
        {
            currentRoomIndex = roomPositions.Length - 1;
        }

        return roomPositions[currentRoomIndex].position;
    }

    public Vector3 MoveToLeftRoom()
    {
        currentRoomIndex--;

        if (currentRoomIndex < 0)
        {
            currentRoomIndex = 0;
        }

        return roomPositions[currentRoomIndex].position;
    }
}
