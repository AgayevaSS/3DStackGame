using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private Vector3 stackOffset;
    [SerializeField] private TMP_Text money;


    [SerializeField] List<Transform> HandTransforms;

    int coffecount;
    bool isEnd;
    private void Start()
    {
        StackHolder.Instance.iceCreamList.Add(transform.GetChild(0));
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, verticalSpeed) * (speed * Time.deltaTime);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8f, 8f),
            transform.position.y,
            transform.position.z);

        if (isEnd)
            return;

        FollowStack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            coffecount++;
            other.AddComponent<CollectedIceCream>();
            StackHolder.Instance.iceCreamList.Add(other.transform);
            //UIManager.Instance.UpdateCoinValue();

            money.text = (coffecount * 3).ToString();

            other.tag = "Collected";
            // StackHolder.Instance.AnimateCollectables();
        }
        else if (other.CompareTag("Finish"))
        {
            isEnd = true;
            speed = 0;
            for (int i = 1; i < StackHolder.Instance.iceCreamList.Count; i++)
            {
                Transform currentPos = StackHolder.Instance.iceCreamList[i].transform;

                currentPos.DOMove(HandTransforms[Random.Range(0, HandTransforms.Count)].position, 0.5f);

            }

        }
    }

    private void FollowStack()
    {
        for (int i = 1; i < StackHolder.Instance.iceCreamList.Count; i++)
        {
            Vector3 prevPos = StackHolder.Instance.iceCreamList[i - 1].transform.position + stackOffset;
            Vector3 currentPos = StackHolder.Instance.iceCreamList[i].transform.position;

            StackHolder.Instance.iceCreamList[i].transform.position =
                Vector3.Lerp(currentPos, prevPos, lerpSpeed * Time.deltaTime);
        }
    }
    public Transform objectToMove; // Ссылка на объект, который нужно поднять вверх

    public void EndGameAnimation()
    {
        float duration = 1.0f; // Продолжительность анимации подъема
        float height = 5.0f; // Высота, на которую нужно поднять объект

        // Используем метод DOMove для перемещения объекта вверх
        objectToMove.DOMove(objectToMove.position + new Vector3(0, height, 0), duration);
    }
}
