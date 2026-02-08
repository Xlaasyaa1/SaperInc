using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaProgress : MonoBehaviour
{
    public static MetaProgress instance;

    public int maxHealth = 10;
    public int gridSize = 8;
    public int sapperUses = 1;
    public int metaCurrency;
    public int coinsPerCell = 1;
    public int currencyPlus = 1;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("meta_currency", metaCurrency);
        PlayerPrefs.SetInt("max_health", maxHealth);
        PlayerPrefs.SetInt("grid_size", gridSize);
        PlayerPrefs.SetInt("currency_plus", currencyPlus);
        PlayerPrefs.SetInt("coins_pre_cell", coinsPerCell);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        metaCurrency = PlayerPrefs.GetInt("meta_currency", 0);
        maxHealth = PlayerPrefs.GetInt("max_health", 10);
        gridSize = PlayerPrefs.GetInt("grid_size", 8);
        currencyPlus = PlayerPrefs.GetInt("currency_plus", 1);
        coinsPerCell = PlayerPrefs.GetInt("coins_per_cell", 1);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();

        metaCurrency = 0;
        maxHealth = 10;
        gridSize = 8;
        coinsPerCell = 1;
        currencyPlus = 1;
        
    }

    void OnApplicationQuit()
    {
        Save();
    }
}