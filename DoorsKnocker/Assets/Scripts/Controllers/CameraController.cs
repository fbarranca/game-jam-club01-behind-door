using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public float transitionSpeed = 5f;
    public Camera mainCamera;

    // Property to check if a transition is currently happening
    public bool IsTransitioning { get; private set; }

    void Awake()
    {
        // Ensure only one instance of CameraController exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate CameraController found. Destroying the duplicate.");
            Destroy(gameObject);
        }
    }

    public void MoveCameraTo(Vector3 targetPosition)
    {
        StartCoroutine(TransitionCamera(targetPosition, transitionSpeed));
    }

    IEnumerator TransitionCamera(Vector3 targetPosition, float transitionSpeed)
    {
        IsTransitioning = true;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            yield break;
        }

        float cameraZIndex = mainCamera.transform.localPosition.z;

        while (Vector2.Distance(new Vector2(mainCamera.transform.position.x, mainCamera.transform.position.y), new Vector2(targetPosition.x, targetPosition.y)) > 0.1f)
        {
            Vector3 newPosition = Vector3.Lerp(mainCamera.transform.position, new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z), Time.deltaTime * transitionSpeed);
            newPosition.z = cameraZIndex; // Keep the z position unchanged
            mainCamera.transform.position = newPosition;
            yield return null;
        }

        IsTransitioning = false;
    }
}
