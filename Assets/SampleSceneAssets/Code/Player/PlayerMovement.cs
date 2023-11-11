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
    private PlayerAnimation playerAnimation;
    [SerializeField] private Transform[] foots;
    private PlayerUnit playerUnit;

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
        playerUnit = GetComponent<PlayerUnit>();
        playerAnimation = GetComponent<PlayerAnimation>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        switch (playerUnit.cameraView)
        {
            case PlayerUnit.View.Normal:
                MovementUpdate();
                JumpUpdate();
                break;
            case PlayerUnit.View.Ball:
                MovementForwardUpdate();
                break;
            case PlayerUnit.View.CantMove:
                direction = new Vector3(0, rb.velocity.y, 0);
                break;
            default:
                break;
        }
    }

    private void MovementForwardUpdate()
    {
        Vector2 movement = movementInput.action.ReadValue<Vector2>();
        direction = transform.forward * movement.y + transform.right * movement.x;
        direction = direction.normalized * speedMovement;
        direction.y = rb.velocity.y;
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
                playerAnimation.TriggerAnimator("Jump");
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
