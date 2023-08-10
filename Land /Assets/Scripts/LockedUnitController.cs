using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedUnitController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int price;

    [Header("Objects")]
    [SerializeField] TextMeshPro priceText;
    [SerializeField] GameObject lockedUnit;
    [SerializeField] GameObject unLockedUnit;

    bool isPurchased;

    void Start()
    {
        priceText.text = price.ToString();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !isPurchased)
        {
            OpenUnit();
        }    
    }

    private void OpenUnit()
    {
        if(CashManager.instance.TryBuyThisUnit(price))
        {
            UnlockObjectsActive();
        }
    }

    private void UnlockObjectsActive()
    {
        isPurchased = true;
        lockedUnit.SetActive(false);
        unLockedUnit.SetActive(true);
    }
}
