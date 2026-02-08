using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RunManager : MonoBehaviour
{
    public static RunManager instance;

    public int maxHealth = 10;
    public int health;
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public int currency;
    public int coinsPerCellRun;
    public TextMeshProUGUI currencyText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHealth = MetaProgress.instance.maxHealth;
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        currency = 0;
        coinsPerCellRun = MetaProgress.instance.coinsPerCell;
        UpdateUI();
    }

    public void SpendClick()
    {
        health -= GetClickDamage();
        UpdateUI();

        if (health <= 0)
        {
            EndRun();
        }
    }

    int GetClickDamage()
    {
        return 1 + (PlayerProgress.instance.level / 5);
    }

    public void AddCurrency(int amount)
    {
        currency += amount * coinsPerCellRun;
        UpdateUI();
    }

 
    void UpdateUI()
    {
        if (healthSlider != null)
            healthSlider.value = health;

        if (currencyText != null)
            currencyText.text = "money: " + currency;
    }

    public void EndRun()
    {
        MetaProgress.instance.metaCurrency += currency;
        UnityEngine.SceneManagement.SceneManager.LoadScene("UpgradeMenu");
    }

    
}