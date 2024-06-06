using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomBuilder : MonoBehaviour
{
    public Transform[] roomPositions;
    public GameObject[] doorPrefabs;


    void Awake()
    {
        InstantiateDoors();
    }

    void InstantiateDoors()
    {
        // Instantiate a door at each predefined position
        foreach (Transform roomPosition in roomPositions)
        {
            InstantiateDoor(roomPosition);
        }
    }

    void InstantiateDoor(Transform roomPosition)
    {
        // Instantiate a door at the specified position
        GameObject door = Instantiate(GetRandomDoor(), roomPosition.position, Quaternion.identity);
        door.transform.SetParent(roomPosition);
    }

    private GameObject GetRandomDoor()
    {
        if (doorPrefabs.Length == 0)
        { 
            Debug.Log("No prefabs available in the list.");
            return null;
        }

        int randomIndex = Random.Range(0, doorPrefabs.Length);
        return doorPrefabs[randomIndex];
    }
}
