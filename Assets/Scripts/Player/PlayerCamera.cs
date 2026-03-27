using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputActionReference cameraActions;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float minY, maxY;
    private bool canControlCamera = true;
    private CinemachineOrbitalTransposer orbital;
    private float currentYValue;

    void Awake()
    {
        cameraActions.action.Enable();

        orbital = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!canControlCamera)
        {
            currentYValue = 0;
            return;
        }
        Vector2 currentDelta = cameraActions.action.ReadValue<Vector2>();

        orbital.m_XAxis.Value += currentDelta.x * cameraSensitivity * Time.deltaTime;

        currentYValue -= currentDelta.y * Time.deltaTime;
        currentYValue = Mathf.Clamp(currentYValue, minY, maxY);
        Vector3 lookOffset = orbital.m_FollowOffset;
        lookOffset.y = currentYValue;
        orbital.m_FollowOffset = lookOffset;
    }

    public void SetCameraMovementEnabled(bool enabled)
    {
        canControlCamera = enabled;
    }
}
