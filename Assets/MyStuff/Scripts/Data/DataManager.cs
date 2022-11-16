using UnityEngine;

public static class DataManager
{
    static string currencyKey = "CK";
    static string MaxTimeKey = "MTK";
    public static void LoadData()
    {
        Debug.Log("DataManager.LoadData");

        Data.currency = PlayerPrefs.GetInt(currencyKey);

        Data.maxSeconds = PlayerPrefs.GetInt(MaxTimeKey);
    }
    public static void SaveData()
    {
        Debug.Log("DataManager.SaveData");
        PlayerPrefs.SetInt(currencyKey, Data.currency);

        PlayerPrefs.SetInt(MaxTimeKey, Data.maxSeconds);
    }


}
