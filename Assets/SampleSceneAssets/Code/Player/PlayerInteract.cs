using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InputActionReference interactInput;

    void Update()
    {
        if (interactInput.action.WasPressedThisFrame())
        {

        }
    }
}
