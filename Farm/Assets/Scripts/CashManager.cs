using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public int coins;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void SellProduct(ProductData productData)
    {
        AddCoin(productData.productPrice);
    }

    public void AddCoin(int price)
    {
        coins += price;
        DisplayCoins();
    }

    public void SpendCoin(int price)
    {
        coins -= price;
        DisplayCoins();
    }

    public bool TryBuyThisUnit(int price)
    {
        if(GetCoins() >= price)
        {
            SpendCoin(price);
            return true;
        }
        return false;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void DisplayCoins()
    {
        UIManager.instance.ShowCoinCountOnScreen(coins);
    }
}
