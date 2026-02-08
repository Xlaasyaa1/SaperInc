using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float spacing = 1.1f;

    public Cell cellPrefab;
    public Transform gridParent;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        float offsetX = (width - 1) * spacing / 2f;
        float offsetY = (height - 1) * spacing / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = Instantiate(cellPrefab, gridParent);
                cell.transform.position = new Vector2(
                    x * spacing - offsetX,
                    y * spacing - offsetY
                );
            }
        }
    }
}