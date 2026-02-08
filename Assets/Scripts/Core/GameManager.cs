using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currency;
    public int flagCurrency;

    void Awake()
    {
        instance = this;
    }
}