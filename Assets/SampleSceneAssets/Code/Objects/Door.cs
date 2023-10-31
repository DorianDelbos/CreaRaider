using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform pointToOpen;
    public Transform pointToClose;

    private Vector3 currentPosition;

    private void Start()
    {
        pointToOpen.parent = null;
        pointToClose.parent = null;

        currentPosition = pointToClose.position;
    }

    // TODO : lerp movement

    public void Open()
    {
        currentPosition = pointToOpen.position;
        transform.position = currentPosition;
    }

    public void Close()
    {
        currentPosition = pointToClose.position;
        transform.position = currentPosition;
    }
}
