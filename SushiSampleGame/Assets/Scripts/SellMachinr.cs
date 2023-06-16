using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMachinr : MonoBehaviour
{
    [SerializeField] Transform sellTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            StackHolder.Instance.iceCreamList.Remove(other.transform);
            other.transform.DOMove(sellTransform.position, 1);
        }

        if (other.CompareTag("Collected"))
        {

            StackHolder.Instance.iceCreamList.Remove(other.transform);
            other.transform.DOMove(sellTransform.position, 1);
            return;

        }
        if (other.CompareTag("Chiyelek"))
        {

            StackHolder.Instance.iceCreamList.Remove(other.transform);
            other.transform.DOMove(sellTransform.position, 1);
            return;
        }
        if (other.CompareTag("White"))
        {

            StackHolder.Instance.iceCreamList.Remove(other.transform);
            other.transform.DOMove(sellTransform.position, 1);
            return;
        }
        if (other.CompareTag("Chocolate"))
        {

            StackHolder.Instance.iceCreamList.Remove(other.transform);
            other.transform.DOMove(sellTransform.position, 1);
            return;
        }
    }

}
