using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] TextMeshProUGUI textCurrency;
    private void Start()
    {
        DataManager.onUpdateTime += updateUiTime;
        DataManager.onUpdateCurrency += updateUiCurrency;
        updateUiCurrency();
        updateUiTime();
    }

    void updateUiTime()
    {
        TimeSpan tS = TimeSpan.FromSeconds(Data.currentTimer);
        textTimer.text = tS.Minutes.ToString() +":"+ tS.Seconds.ToString()+":"+tS.Milliseconds.ToString();
    }
    void updateUiCurrency()
    {
        textCurrency.text = Data.currency.ToString();
    }
}
