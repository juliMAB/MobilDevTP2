using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTimer;

    private void Start()
    {
        DataManager.onUpdateTime += updateUiTime;
    }

    void updateUiTime()
    {
        TimeSpan tS = TimeSpan.FromSeconds(Data.currentTimer);
        textTimer.text = tS.Minutes.ToString() +":"+ tS.Seconds.ToString()+":"+tS.Milliseconds.ToString();
    }
}
