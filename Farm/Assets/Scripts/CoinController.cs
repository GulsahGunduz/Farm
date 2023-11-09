using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] int coinPrice;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            CashManager.instance.AddCoin(coinPrice);
            Destroy(gameObject);
        }    
    }


}
