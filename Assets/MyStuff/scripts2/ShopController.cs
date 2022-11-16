using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] Material showMaterial;
    [SerializeField] Color[] color = new Color[6];
    [SerializeField] int[] price = new int[6];
    [SerializeField] GameObject Alert;
    [SerializeField] TextMeshProUGUI BuyButton;
    [SerializeField] TextMeshProUGUI priceText;
    int index =0;

    public void Next()
    {
        index++;
        if (index >= color.Length)
            index = 0;
        showMaterial.color = color[index];
        priceText.text = "Price: " + price[index];
        UpdateLetter();
    }
    public void Previous()
    {
        index--;
        if (index<0)
            index = price.Length-1;
        showMaterial.color = color[index];
        priceText.text = "Price: " + price[index];
        UpdateLetter();
    }
    public void Buy()
    {
        Alert.SetActive(true);
        if (ShopData.Unlocked[index] == true)
        {
            Alert.GetComponent<TextMeshProUGUI>().text = "Equiped";
            ShopData.material = showMaterial;
            Debug.Log("equipaste el color: " + showMaterial.color.ToString());
            DataManager.SaveData();
        }
        else if (Data.currency >= price[index])
        {
            Data.currency -= price[index];
            ShopData.Unlocked[index]=true;
            Alert.GetComponent<TextMeshProUGUI>().text = "Buy!!";
            Debug.Log("realizaste una compra");
            DataManager.SaveData();
        }
        else
        {
            Alert.GetComponent<TextMeshProUGUI>().text = "No Money!!";
            Debug.Log("no tienes dinero para esta compra");
        }
        Alert.GetComponent<Animator>().Play("a");
        Invoke(nameof(AlertDisabled), 2);
        UpdateLetter();
    }
    void AlertDisabled()
    {
        Alert.SetActive(false);
    }
    void UpdateLetter()
    {
        if (ShopData.Unlocked[index] == true)
        {
            BuyButton.text = "E";
            priceText.text = " ";
        }
        else
        {
            BuyButton.text = "B";
        }
        
    }
}
