using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance; // Singleton instance

    void Awake()
    {
        // Ensure only one instance of InputController exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate InputManager found. Destroying the duplicate.");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check for player input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !CameraController.instance.IsTransitioning)
        {
            CameraController.instance.MoveCameraTo(RoomController.instance.MoveToLeftRoom());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !CameraController.instance.IsTransitioning)
        {
            CameraController.instance.MoveCameraTo(RoomController.instance.MoveToRightRoom());
        }
    }
}
