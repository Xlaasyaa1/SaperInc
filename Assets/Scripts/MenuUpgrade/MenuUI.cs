using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    void Update()
    {
        if (MetaProgress.instance == null) return;

        currencyText.text =
            "currency: " + MetaProgress.instance.metaCurrency;
    }
}
