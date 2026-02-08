using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;

    public int level = 1;
    public int exp = 0;
    public int expToNext = 10;

    void Awake()
    {
        instance = this;
    }

    public void AddExp(int amount)
    {
        exp += amount;

        if (exp >= expToNext)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        exp -= expToNext;
        level++;
        expToNext = Mathf.RoundToInt(expToNext * 1.4f);

        SectionManager.instance.TryUnlock(level);
    }
}
