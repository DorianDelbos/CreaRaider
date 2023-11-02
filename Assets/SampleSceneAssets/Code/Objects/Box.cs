using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 startPosition;
    private int environmentLayer;

    private void Start()
    {
        startPosition = transform.position;
        environmentLayer = LayerMask.NameToLayer("Environment");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == environmentLayer)
        {
            transform.position = startPosition;
        }
    }
}
