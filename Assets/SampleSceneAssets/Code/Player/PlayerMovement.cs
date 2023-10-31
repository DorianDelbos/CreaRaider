using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    private Rigidbody rb;

    [Space, Header("Inputs")]
    [SerializeField] private InputActionReference movementInput;
    [SerializeField] private InputActionReference jumpInput;
    [SerializeField] private InputActionReference cameraInput;

    [Space, Header("Settings")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    [SerializeField] private float xMouseSensitivity;
    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraUpdate();
        MovementUpdate();
        JumpUpdate();
    }

    private void CameraUpdate()
    {
        float axis = cameraInput.action.ReadValue<float>();
        Vector3 rotate = new Vector3(0, axis * xMouseSensitivity, 0);
        transform.Rotate(rotate);
    }

    private void MovementUpdate()
    {
        Vector2 movement = movementInput.action.ReadValue<Vector2>();
        direction = transform.forward * movement.y + transform.right * movement.x;
        direction = direction.normalized * speedMovement;
        direction.y = rb.velocity.y;
    }

    private void JumpUpdate()
    {
        if (jumpInput.action.WasPressedThisFrame())
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
