using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public GridManager gridManager;

    public int row;
    public int col;

    private void OnMouseDown()
    {
        gridManager.CheckClickedCell(this);
    }
}
