using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] Transform bag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            AddProductToBag(other.gameObject);
        }
    }

    public void AddProductToBag(GameObject box)
    {
        box.transform.SetParent(bag, true);

        box.transform.localPosition = Vector3.zero;
        box.transform.localRotation = Quaternion.identity;
    }

}
