using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] Transform bag;
    public List<ProductData> productDataList;

    Vector3 boxSize;


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

}
