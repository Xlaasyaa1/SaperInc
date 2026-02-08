using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanLineAbility : MonoBehaviour
{
    public void ScanRow(int y, Cell[,] grid, int width)
    {
        for (int x = 0; x < width; x++)
            Debug.Log(grid[x, y].isMine);
    }
}
