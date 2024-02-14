using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Properties with private setters to maintain encapsulation
    public GameObject cellPrefab;
    public float cellSize;
    public int gridSizeX;
    public int gridSizeY;

    private int targetRow;
    private int targetColumn;

    GridCell targetCell;

    void Start()
    {
        // Calculate the total width and height of the grid
        float totalWidth = gridSizeX * cellSize;
        float totalHeight = gridSizeY * cellSize;

        // Calculate the starting position of the grid
        float startX = -(totalWidth / 2) + (cellSize / 2);
        float startY = -(totalHeight / 2) + (cellSize / 2);

        // Choose a random target cell
        targetRow = Random.Range(0, gridSizeY);
        targetColumn = Random.Range(0, gridSizeX);

        // Loop through each row and column to instantiate and position cells
        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                // Calculate the position of the current cell
                float xPos = startX + (x * cellSize);
                float yPos = startY + (y * cellSize);

                cellPrefab.GetComponent<GridCell>().row = y;
                cellPrefab.GetComponent<GridCell>().col = x;
                cellPrefab.GetComponent<GridCell>().gridManager = this;

                // Instantiate the cell GameObject at the calculated position
                GameObject cell = Instantiate(cellPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                cell.transform.SetParent(transform); // Set the grid GameObject as the parent
            }
        }
    }

    public void CheckClickedCell(GridCell cell)
    {
        if (cell.row == targetRow && cell.col == targetColumn)
        {
            Debug.Log("Right!");
        }
        else
        {
            float distance = CalculateEuclideanDistance(cell);
            int distance2 = CalculateManhattanDistance(cell);
            GetDistanceHint(Mathf.RoundToInt(distance));
        }
    }

    private void GetDistanceHint(int distance)
    {
        switch (distance)
        {
            case 1:
                Debug.Log("You're very close to the correct cell!");
                break;
            case 2:
                Debug.Log("You're close to the correct cell.");
                break;
            default:
                Debug.Log("You're far from the correct cell.");
                break;
        }
    }

    private float CalculateEuclideanDistance(GridCell cell)
    {
        float dx = cell.row - targetRow;
        float dy = cell.col - targetColumn;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }

    int CalculateManhattanDistance(GridCell cell)
    {
        return Mathf.Abs(cell.row - targetRow) + Mathf.Abs(cell.col - targetColumn);
    }
}
