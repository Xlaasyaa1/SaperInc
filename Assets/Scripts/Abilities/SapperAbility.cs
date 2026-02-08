using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapperAbility : MonoBehaviour
{
    public int uses = 3;

    public void Use(Cell center)
    {
        if (uses <= 0) return;
        uses--;

        for (int dx = -1; dx <= 1; dx++)
        for (int dy = -1; dy <= 1; dy++)
        {
            // здесь ты позже получишь соседние клетки и откроешь безопасные
        }
    }
}
