using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstactle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectedIceCream collectedCoffee))
        {
            int index = StackHolder.Instance.iceCreamList.IndexOf(other.transform);

            for (int i = Mathf.Max(1, index); i < StackHolder.Instance.iceCreamList.Count; i++)
            {
                Transform coffee = StackHolder.Instance.iceCreamList[i];

                coffee.tag = "Collectable";

                Vector3 jumpPosition = coffee.position + new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));

                StackHolder.Instance.iceCreamList.Remove(coffee);

                coffee.DOJump(jumpPosition, 0.5f, 1, 0.3f);
            }
        }
    }
}
