using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectedIceCream : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.AddComponent<CollectedIceCream>();
            other.tag = "Collected";
            //StackHolder.Instance.iceCreamList.Add(other.transform);

            //UIManager.Instance.UpdateCoinValue();

            //StackHolder.Instance.AnimateCollectables();
        }
    }
}
