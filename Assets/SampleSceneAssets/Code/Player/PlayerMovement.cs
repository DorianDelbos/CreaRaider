using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    private Rigidbody rb;
    [SerializeField] private Transform[] foots;

    [Space, Header("Inputs")]
    [SerializeField] private InputActionReference movementInput;
    [SerializeField] private InputActionReference jumpInput;

    [Space, Header("Settings")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    private Vector3 direction;
    private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }

    private void MovementUpdate()
    {
        Vector2 movement = movementInput.action.ReadValue<Vector2>();
        direction = Camera.main.transform.forward * movement.y + Camera.main.transform.right * movement.x;
        direction = direction.normalized * speedMovement;
        direction.y = rb.velocity.y;
    }

    private void JumpUpdate()
    {
        if (jumpInput.action.WasPressedThisFrame())
        {
            if (CanJump())
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private bool CanJump()
    {
        foreach (var foot in foots)
        {
            if (Physics.OverlapSphere(foot.position, 0.1f, groundLayer).Count() > 0)
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
