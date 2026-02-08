using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public bool isMine;
    SpriteRenderer sr;
    TextMeshPro text;
    bool flagged;
    public int number;
    public bool opened;
    public TextMeshProUGUI currencyText;


    public int x, y;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        text.text = "";
    }

    void OnMouseDown()
    {
        if (opened) return;

        RunManager.instance.SpendClick();
        if (RunManager.instance.health <= 0) return;

        opened = true;

        if (isMine)
        {
            sr.color = Color.red;
            RunManager.instance.EndRun();
        }
        else
        {
            sr.color = Color.white;
            text.text = number == 0 ? "" : number.ToString();
            RunManager.instance.AddCurrency(1);
    }
}
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleFlag();
        }
    }

    void ToggleFlag()
    {
        if (flagged) 
        {
            flagged = false;
            sr.color = new Color(0.6f, 0.6f, 0.6f);
        }
        else
        {
            flagged = true;
            sr.color = Color.yellow;
        }
    }

    public void CalculateNumber(Cell[,] grid, int width, int height)
    {
        Debug.Log("number = " + number);
        if (isMine) 
        {
            number = -1;
            return;
        }

        int count = 0;
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && ny >= 0 && nx < width && ny < height)
                {
                    if (grid[nx, ny].isMine)
                        count++;
                }
            }
        }
        number = count;
    }

    int GetDamage()
    {
        return 1 + (PlayerProgress.instance.level / 5);
    }
}