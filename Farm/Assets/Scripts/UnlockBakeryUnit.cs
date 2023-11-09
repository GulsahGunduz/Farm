using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockBakeryUnit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bakeryText;
    [SerializeField] int maxStoredProductCount;
    [SerializeField] ProductType productType;
    int storedProductCount;

    [SerializeField] int useProductInSeconds = 5;
    [SerializeField] Transform coinTransform;
    [SerializeField] GameObject coinGO;
    float useTime;

    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem fireParticle;

    private void Start()
    {
        DisplayProductCount();
    }

    void Update()
    {
        if(storedProductCount > 0)
        {
            useTime += Time.deltaTime;

            if(useTime >= useProductInSeconds)
            {
                useTime = 0f;
                ExchangeProduct();
            }
        }        
    }

    void DisplayProductCount()
    {
        bakeryText.text = storedProductCount.ToString() + "/" + maxStoredProductCount.ToString();
        ControlSmokeEffect();
    }

    public ProductType GetNeededProductType()
    {
        return productType;
    }

    public bool StoreProduct()
    {
        if(maxStoredProductCount == storedProductCount)
        {
            return false;
        }
        storedProductCount++;
        DisplayProductCount();
        return true;
    }

    void ExchangeProduct()
    {
        storedProductCount--;
        DisplayProductCount();
        CreateCoin();
    }

    void CreateCoin()
    {
        Vector3 pos = Random.insideUnitSphere * 1f;
        Vector3 instantiatePos = coinTransform.position + pos;
        
        Instantiate(coinGO, instantiatePos, Quaternion.identity);
    }

    void ControlSmokeEffect()
    {
        if(storedProductCount == 0)
        {
            if(smokeParticle.isPlaying)
            {
                smokeParticle.Stop();
                fireParticle.Stop();
            }
        }else{
            if(smokeParticle.isStopped)
            {
                smokeParticle.Play();
                fireParticle.Play();
            }
        }
    }
}
