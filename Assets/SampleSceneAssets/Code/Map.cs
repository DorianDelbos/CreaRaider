using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    [SerializeField] private GameObject inventoryPanel;
    private Camera cameraComponent;

    [Space, Header("Inputs")]
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference zoomInput;

    [Space, Header("Settings")]
    [SerializeField] private float mouseSensitivity = 0.05f;
    [SerializeField] private Vector2 minMaxSize;
    private Vector2 lastPosition;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
    }

    void Update()
    {
        if (!inventoryPanel.activeSelf)
            return;

        float zoomDelta = zoomInput.action.ReadValue<float>();
        cameraComponent.orthographicSize = Mathf.Clamp(cameraComponent.orthographicSize + zoomDelta, minMaxSize.x, minMaxSize.y);

        if (moveInput.action.WasPressedThisFrame())
        {
            lastPosition = Input.mousePosition;
        }

        if (moveInput.action.IsPressed())
        {
            Vector2 currentPosition = Input.mousePosition;

            Vector2 delta = (currentPosition - lastPosition) * cameraComponent.orthographicSize * mouseSensitivity;
            transform.position -= new Vector3(delta.x, 0, delta.y);

            lastPosition = currentPosition;
        }
    }
}
