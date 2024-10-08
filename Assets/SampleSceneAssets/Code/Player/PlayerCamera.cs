using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    [SerializeField] private Transform followTransform;
    private PlayerUnit playerUnit;

    [Space, Header("Inputs")]
    [SerializeField] private InputActionReference cameraMovementInput;

    [Space, Header("Settings")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float rotationLerp;
    private Quaternion nextRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerUnit = GetComponent<PlayerUnit>();
    }

    private void Update()
    {
        switch (playerUnit.cameraView)
        {
            case PlayerUnit.View.Normal:
                thirdPersonCameraUpdate();
                break;
            default: 
                break;
        }
    }

    public void thirdPersonCameraUpdate()
    {
        Vector2 axis = cameraMovementInput.action.ReadValue<Vector2>();

        // Horizontal
        nextRotation *= Quaternion.AngleAxis(axis.x * mouseSensitivity, Vector3.up);

        // Vertical
        nextRotation *= Quaternion.AngleAxis(-axis.y * mouseSensitivity, Vector3.right);

        Vector3 angles = nextRotation.eulerAngles;
        angles.z = 0;

        float angle = angles.x;

        // Clamp vertical
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        nextRotation.eulerAngles = angles;

        Quaternion curRotationFollow = Quaternion.Lerp(followTransform.rotation, nextRotation, Time.deltaTime * rotationLerp);
        followTransform.localRotation = Quaternion.Euler(curRotationFollow.eulerAngles.x, 0, 0);

        Quaternion curRotation = Quaternion.Lerp(transform.rotation, nextRotation, Time.deltaTime * rotationLerp);
        transform.localRotation = Quaternion.Euler(0, curRotation.eulerAngles.y, 0);
    }

    public void ChangeCamera(CinemachineVirtualCamera camera)
    {
        Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Priority = 5;
        camera.Priority = 50;
    }
}
