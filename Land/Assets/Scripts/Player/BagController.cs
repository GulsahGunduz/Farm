using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagController : MonoBehaviour
{
    [SerializeField] TextMeshPro maxText;
    [SerializeField] Transform bag;

    public List<ProductData> productDataList;

    Vector3 boxSize;
    int maxBagCapacity = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShopPoint"))
        {
            for (int i = productDataList.Count - 1; i >= 0; i--)
            {
                SellProductsToShop(productDataList[i]);
                Destroy(bag.transform.GetChild(i).gameObject);
                productDataList.RemoveAt(i);
            }
            ControlBagCapacity();
        }
    }

    public void SellProductsToShop(ProductData productData)
    {
        CashManager.instance.SellProduct(productData);
    }

    public void AddProductToBag(ProductData productData)
    {
        GameObject boxProduct = Instantiate(productData.productPrefab, Vector3.zero, Quaternion.identity);
        boxProduct.transform.SetParent(bag, true);

        CalculateObjectSize(boxProduct);
        float yPos = CalculateNewYPositionOfBox();

        boxProduct.transform.localPosition = Vector3.zero;
        boxProduct.transform.localRotation = Quaternion.identity;
        boxProduct.transform.localPosition = new Vector3(0, yPos, 0);
        
        productDataList.Add(productData);
        ControlBagCapacity();
    }

    float CalculateNewYPositionOfBox()
    {
        float newYPos = boxSize.y * productDataList.Count;
        return newYPos;
    }

    void CalculateObjectSize(GameObject obj)
    {
        if (boxSize == Vector3.zero)
        {
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            boxSize = renderer.bounds.size;
        }
    }

    void ControlBagCapacity()
    {
        if (productDataList.Count == maxBagCapacity)
        {
            SetMaxTextOn();
        }
        else
        {
            SetMaxTextOff();
        }
    }

    void SetMaxTextOn()
    {
        if (!maxText.isActiveAndEnabled)
        {
            maxText.gameObject.SetActive(true);
        }
    }

    void SetMaxTextOff()
    {
        if (maxText.isActiveAndEnabled)
        {
            maxText.gameObject.SetActive(false);
        }
    }

    public bool IsEmptySpace()
    {
        if(productDataList.Count < maxBagCapacity)
        {
            return true;
        }
        return false;
    }
}
