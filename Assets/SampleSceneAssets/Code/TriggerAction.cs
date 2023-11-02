using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{
    public UnityEvent action;
    [SerializeField] private string tagCompared;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagCompared))
        {
            action?.Invoke();
        }
    }
}
