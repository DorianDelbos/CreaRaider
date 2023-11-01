using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform pointToOpen;
    public Transform pointToClose;

    private Coroutine coroutine;
    private Vector3 currentPosition;
    private bool isOpen = false;

    [SerializeField] private float duration = 3;

    private void Start()
    {
        pointToOpen.parent = null;
        pointToClose.parent = null;

        currentPosition = pointToClose.position;
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;
        transform.position = currentPosition;
        currentPosition = pointToOpen.position;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(LerpPosition());
    }

    public void Close()
    {
        if (!isOpen)
            return;

        isOpen = false;
        transform.position = currentPosition;
        currentPosition = pointToClose.position;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(LerpPosition());
    }

    private IEnumerator LerpPosition()
    {
        Vector3 startPosition = transform.position;

        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, currentPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = currentPosition;
    }
}
