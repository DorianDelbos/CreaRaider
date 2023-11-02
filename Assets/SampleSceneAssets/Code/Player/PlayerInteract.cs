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
    [SerializeField] private float maxDistance;
    private int environmentLayer;

    private void Start()
    {
        environmentLayer = LayerMask.GetMask("Environment") | LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (interactInput.action.WasPressedThisFrame())
        {
            Transform cameraTransform = Camera.main.transform;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, maxDistance, environmentLayer))
            {
                Debug.DrawLine(cameraTransform.position, hit.point, Color.red, 10);

                Collider[] allCollide = Physics.OverlapSphere(hit.point, radiusInteract).Where(t => t.GetComponent<Interactable>()).ToArray();

                foreach (Collider col in allCollide)
                {
                    col.GetComponent<Interactable>().onObjectInteract?.Invoke();
                }
            }
        }
    }
}
