using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHolder : MonoBehaviour
{
    public List<Transform> iceCreamList;
    public static StackHolder Instance { get; private set; }

    private Sequence sequence;

    private void Awake()
    {
        iceCreamList = new List<Transform>();

        if (Instance == null)
        {
            Instance = this;
        }
    }

    //public void AnimateCollectables()
    //{
    //    sequence = DOTween.Sequence();
    //    sequence.Kill();
    //    sequence = DOTween.Sequence();
    //    for (int i = iceCreamList.Count - 1; i > 0; i--)
    //    {
    //        sequence.Join(iceCreamList[i].DOScale(1.5f, 0.1f));
    //        sequence.AppendInterval(0.05f);
    //        sequence.Join(iceCreamList[i].DOScale(1f, 0.1f));
    //    }
    //}
    public void AnimateCollectables(float durationМеждуОбъектами = 0.1f, float durationМасштабирования = 0.1f, float множительМасштаба = 1.5f)
    {
        sequence = DOTween.Sequence();
        sequence.Kill();
        sequence = DOTween.Sequence();
        for (int i = iceCreamList.Count - 1; i >= 0; i--)
        {
            sequence.AppendInterval(durationМеждуОбъектами);
            sequence.Append(iceCreamList[i].DOScale(множительМасштаба, durationМасштабирования));
            sequence.Append(iceCreamList[i].DOScale(1f, durationМасштабирования));
        }
    }

}
