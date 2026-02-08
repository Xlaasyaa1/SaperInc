using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartRun()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpgradeHealth()
    {
        int cost = 5;

        if (MetaProgress.instance.metaCurrency < cost)
            return;

        MetaProgress.instance.metaCurrency -= cost;
        MetaProgress.instance.maxHealth += 1;

        MetaProgress.instance.Save();
    }

    public void UpgradeCoinsPerCell()
    {
        int coinsPerCellCost = 5;

        if (MetaProgress.instance.metaCurrency < coinsPerCellCost)
            return;

        MetaProgress.instance.metaCurrency -= coinsPerCellCost;
        MetaProgress.instance.coinsPerCell += 1;

        MetaProgress.instance.Save();
    }
}
