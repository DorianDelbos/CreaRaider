using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTransform : MonoBehaviour
{
    [SerializeField] private Transform toBeFixed;

    private void Update()
    {
        if (toBeFixed == null)
            return;

        transform.position = toBeFixed.position;
    }
}
