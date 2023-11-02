using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Transform lastPosition;
    [SerializeField] private float duration;

    public void StartMoving()
    {
        startPosition = transform.position;
        lastPosition.parent = transform.parent;

        StartCoroutine(MovePlatform(lastPosition.position));
    }

    private IEnumerator MovePlatform(Vector3 position)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, position, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = position;
    }
}
