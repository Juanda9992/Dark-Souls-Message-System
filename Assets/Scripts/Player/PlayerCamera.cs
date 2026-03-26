using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private InputActionReference cameraActions;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private float minY,maxY;
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
        Vector2 currentDelta = cameraActions.action.ReadValue<Vector2>();

        orbital.m_XAxis.Value += currentDelta.x * Time.deltaTime;

        currentYValue -= currentDelta.y * Time.deltaTime;
        currentYValue = Mathf.Clamp(currentYValue,minY,maxY);
        Vector3 lookOffset = orbital.m_FollowOffset;
        lookOffset.y = currentYValue;
        orbital.m_FollowOffset = lookOffset;
    }
}
