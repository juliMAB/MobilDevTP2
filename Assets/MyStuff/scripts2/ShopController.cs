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
    public void Next()
    {
        ShopData.shopIndex++;
        if (ShopData.shopIndex >= color.Length)
            ShopData.shopIndex = 0;
        showMaterial.color = color[ShopData.shopIndex];
        priceText.text = "Price: " + price[ShopData.shopIndex];
        UpdateLetter();
    }
    public void Previous()
    {
        ShopData.shopIndex--;
        if (ShopData.shopIndex<0)
            ShopData.shopIndex = price.Length-1;
        showMaterial.color = color[ShopData.shopIndex];
        priceText.text = "Price: " + price[ShopData.shopIndex];
        UpdateLetter();
    }
    public void Buy()
    {
        Alert.SetActive(true);
        if (ShopData.Unlocked[ShopData.shopIndex] == true)
        {
            Alert.GetComponent<TextMeshProUGUI>().text = "Equiped";
            ShopData.material = showMaterial;
            Debug.Log("equipaste el color: " + showMaterial.color.ToString());
            DataManager.SaveData();
        }
        else if (Data.currency >= price[ShopData.shopIndex])
        {
            Data.currency -= price[ShopData.shopIndex];
            ShopData.Unlocked[ShopData.shopIndex]=true;
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
        if (ShopData.Unlocked[ShopData.shopIndex] == true)
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
