using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject CurrencyUIGO;
    [SerializeField] GameObject MenuUIGO;
    [SerializeField] GameObject PluginsUIGO;
    [SerializeField] GameObject ShopUIGO;

    [SerializeField] Button bt_MenugoPlugin;
    [SerializeField] Button bt_MenuGoShop;
    [SerializeField] Button bt_MenuGoAchivements;
    [SerializeField] Button bt_MenuGoLiderBoard;
    [SerializeField] Button bt_play;

    [SerializeField] Button bt_ShopGoMenu;

    [SerializeField] Button bt_PluginGoMenu;

    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] TextMeshProUGUI maxTimeText;

    private void Start()
    {
        CurrencyUIGO.SetActive(true);
        MenuUIGO.SetActive(true);

        bt_play.onClick.AddListener(() => { Debug.Log("play"); SceneManager.LoadScene(1); });
        
        bt_MenugoPlugin.onClick.AddListener(() => { MenuUIGO.SetActive(false); CurrencyUIGO.SetActive(false); PluginsUIGO.SetActive(true); });
        bt_PluginGoMenu.onClick.AddListener(() => { MenuUIGO.SetActive(true); CurrencyUIGO.SetActive(true); PluginsUIGO.SetActive(false); });

        bt_MenuGoShop.onClick.AddListener(() => { MenuUIGO.SetActive(false); ShopUIGO.SetActive(true); });
        bt_ShopGoMenu.onClick.AddListener(() => { MenuUIGO.SetActive(true); ShopUIGO.SetActive(false); });

        bt_MenuGoLiderBoard.onClick.AddListener(() => { Debug.Log("Show LiderBoard"); MyGooglePlayGames.ShowLeaderboard(); });
        bt_MenuGoAchivements.onClick.AddListener(() => { Debug.Log("Show Achivement"); MyGooglePlayGames.ShowAchievements(); });

        System.Action action = updateData;
        Invoke(action.Method.Name, 0.5f);

    }
    void updateData()
    {
        currencyText.text = Data.currency.ToString();

        TimeSpan tS = TimeSpan.FromSeconds(Data.maxSeconds);
        maxTimeText.text = tS.Minutes.ToString() + ":" + tS.Seconds.ToString() + ":" + tS.Milliseconds.ToString();
    }

}
