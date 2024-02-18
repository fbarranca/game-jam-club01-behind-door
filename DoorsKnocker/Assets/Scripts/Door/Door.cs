using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public GameObject targetSpot;
    public Animator animator;

    void Start()
    {
        Vector3 randomPosition = GenerateRandomPosition();

        // Move the target spot to the random position
        targetSpot.transform.position = randomPosition;
    }

    // Called when a pointer click is detected on the door
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector2 targetPosition = targetSpot.transform.position;
        float distance = Vector2.Distance(clickPosition, targetPosition);

        if (distance < 1.0f) // Adjust the threshold value as needed
        {
            Debug.Log("You're very close to the target spot!");
        }
        else if (distance < 2.0f) // Adjust the threshold value as needed
        {
            Debug.Log("You're close to the target spot.");
        }
        else
        {
            Debug.Log("You're far from the target spot.");
        }

        if (eventData.pointerPress == targetSpot)
        {
            
            targetSpot.GetComponent<TargetSpot>().DeactivateDoor();            
        }

    }
    public Vector3 GenerateRandomPosition()
    {
        Vector3 doorSize = GetComponent<BoxCollider2D>().size;
        // Get the bounds of the target spot area
        Bounds doorBounds = new Bounds(transform.position, doorSize);

        // Generate random x and y coordinates within the bounds of the door GameObject
        float randomX = Random.Range(doorBounds.min.x, doorBounds.max.x);
        float randomY = Random.Range(doorBounds.min.y, doorBounds.max.y);

        // Return the random position
        return new Vector3(randomX, randomY, transform.position.z);
    }

    public void MoveTargetSpotToRandomPosition()
    {
        targetSpot.GetComponent<TargetSpot>().MoveToPosition(GenerateRandomPosition());
    }

    public void DeactivateDoor()
    {
        gameObject.SetActive(false);
    }

    public void BreakAnimation()
    {
        animator.SetTrigger("Break");
    }
}
