using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSpot : MonoBehaviour, IPointerClickHandler
{
    public GameObject door;

    public void DeactivateDoor()
    {
        Debug.Log("Target Spot!");

        gameObject.SetActive(false);
        door.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DeactivateDoor();
    }

    public void MoveToPosition(Vector3 position)
    {
        transform.position = position;
    }
}
