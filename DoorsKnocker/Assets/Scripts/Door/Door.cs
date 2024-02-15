using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public GameObject targetSpot;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = GenerateRandomPosition();

        // Move the target spot to the random position
        targetSpot.transform.position = randomPosition;
    }

    // Called when a pointer click is detected on the door
    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the click occurred on the door
        if (eventData.pointerPress == targetSpot)
        {
            // Door clicked, reveal target spot
            targetSpot.GetComponent<TargetSpot>().DeactivateDoor();
        }

    }
    Vector3 GenerateRandomPosition()
    {
        //Vector3 doorSize = transform.localScale;
        Vector3 doorSize = GetComponent<BoxCollider2D>().size;
        // Get the bounds of the target spot area
        Bounds doorBounds = new Bounds(transform.position, doorSize);

        // Generate random x and y coordinates within the bounds of the door GameObject
        float randomX = Random.Range(doorBounds.min.x, doorBounds.max.x);
        float randomY = Random.Range(doorBounds.min.y, doorBounds.max.y);

        // Return the random position
        return new Vector3(randomX, randomY, transform.position.z);
    }
}
