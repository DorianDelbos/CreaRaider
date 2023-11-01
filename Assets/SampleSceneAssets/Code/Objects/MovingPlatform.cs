using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;

    [Space, Header("Settings")]
    [SerializeField] private float duration;

    private void Start()
    {
        firstPosition.parent = transform.parent;
        secondPosition.parent = transform.parent;

        StartCoroutine(MovePlatform(firstPosition.position, secondPosition.position));
    }

    private IEnumerator MovePlatform(Vector3 firstPosition, Vector3 secondPosition)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(firstPosition, secondPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = secondPosition;

        StartCoroutine(MovePlatform(secondPosition, firstPosition));
    }
}
