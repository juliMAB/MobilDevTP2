using UnityEngine;

public static class DataManager
{
    static string currencyKey = "CK";
    static string MaxTimeKey = "MTK";
    static string UnlokedKey = "SHUK";
    public static void LoadData()
    {
        Debug.Log("DataManager.LoadData");

        Data.currency = PlayerPrefs.GetInt(currencyKey);

        Data.maxSeconds = PlayerPrefs.GetInt(MaxTimeKey);

        for (int i = 0; i < ShopData.StoreStufs; i++)
        {
            int v = PlayerPrefs.GetInt(UnlokedKey + i.ToString(),-1);
            if (v >= 0)
            {
                if (v==0)
                    ShopData.Unlocked[i] = false;
                if (v==1)
                    ShopData.Unlocked[i] = true;
            }

        }
    }
    public static void SaveData()
    {
        Debug.Log("DataManager.SaveData");
        PlayerPrefs.SetInt(currencyKey, Data.currency);

        PlayerPrefs.SetInt(MaxTimeKey, Data.maxSeconds);

        for (int i = 0; i < ShopData.StoreStufs; i++)
        {
            if (true == ShopData.Unlocked[i])
                PlayerPrefs.SetInt(UnlokedKey + i.ToString(), 1);
            if (false == ShopData.Unlocked[i])
                PlayerPrefs.SetInt(UnlokedKey + i.ToString(), 0);
        }
    }


}
