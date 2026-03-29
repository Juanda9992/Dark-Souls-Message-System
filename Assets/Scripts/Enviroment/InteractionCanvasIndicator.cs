using UnityEngine;

public class InteractionCanvasIndicator : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    void Update()
    {
        transform.LookAt(2* transform.position -_mainCamera.transform.position);
    }
}
