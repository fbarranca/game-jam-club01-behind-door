using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetSpot : MonoBehaviour, IPointerClickHandler
{
    public GameObject door;

    public void DeactivateDoor()
    {
        gameObject.SetActive(false);
        door.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreController.IncreaseScore();
        DeactivateDoor();
        Debug.Log(ScoreController.GetScore());
    }

    public void MoveToPosition(Vector3 position)
    {
        transform.position = position;
    }
}
