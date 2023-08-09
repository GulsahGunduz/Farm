using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlantController : MonoBehaviour
{
    [SerializeField] ProductData productData;
    [SerializeField] float growUpTime;

    Vector3 originalScale;
    BagController bagController;
    
    bool isReadyToPick;

    void Start()
    {
        isReadyToPick = true;
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToPick)
        {
            bagController = other.gameObject.GetComponent<BagController>();

            if (bagController.IsEmptySpace())
            {
                bagController.AddProductToBag(productData);
                StartCoroutine(ProductPicked());
            }

        }
    }

    IEnumerator ProductPicked()
    {
        isReadyToPick = false;
        Vector3 targetScale = originalScale / 2.5f;
        transform.DOScale(targetScale, 1f);

        yield return new WaitForSeconds(growUpTime);

        transform.DOScale(originalScale, 5f).SetEase(Ease.InOutBack);
        isReadyToPick = true;
    }
}
