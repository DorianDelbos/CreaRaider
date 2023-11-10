using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private float timeToWait = 2f;
    private Coroutine coroutine;

    public void SetTemporyCameraCinematic(CinemachineVirtualCamera virtualCamera)
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(CameraMovement(virtualCamera));
        }
    }
    
    private IEnumerator CameraMovement(CinemachineVirtualCamera virtualCamera)
    {
        virtualCamera.Priority = 20;

        yield return new WaitForSecondsRealtime(timeToWait);

        virtualCamera.Priority = 0;

        coroutine = null;
    }
}
