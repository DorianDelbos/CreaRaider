using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private Transform interactTransform;
    [SerializeField] private float radiusInteract;

    void Update()
    {
        if (interactInput.action.WasPressedThisFrame())
        {
            Collider[] allCollide = Physics.OverlapSphere(interactTransform.position, radiusInteract).Where(t => t.GetComponent<Interactable>()).ToArray();

            foreach (Collider col in allCollide)
            {
                col.GetComponent<Interactable>().onObjectInteract?.Invoke();
            }
        }
    }
}
