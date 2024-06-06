using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public GameObject targetSpot;
    public Animator animator;
    public Animator knock;

    // Define animation triggers
    public string strongTrigger = "StrongKnock";
    public string midTrigger = "MidKnock";
    public string farTrigger = "WeakKnock";

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
            GetHintAnimation(clickPosition);
            knock.SetTrigger(strongTrigger);
        }
        else if (distance < 2.0f) // Adjust the threshold value as needed
        {
            GetHintAnimation(clickPosition);
            knock.SetTrigger(midTrigger);
        }
        else
        {
            GetHintAnimation(clickPosition);
            knock.SetTrigger(farTrigger);
        }

        if (eventData.pointerPress == targetSpot)
        {
            
            targetSpot.GetComponent<TargetSpot>().DeactivateDoor();            
        }

    }

    private void GetHintAnimation(Vector2 clickPosition)
    {
        knock.transform.position = clickPosition;
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
