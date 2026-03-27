using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMessageHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnStartWriting;
    [SerializeField] private GameObject messageCanvas;
    [SerializeField] private InputActionReference writeAction;


    private float timeToActivateMessageCanvas = 2f;
    void Awake()
    {
        writeAction.action.Enable();

        writeAction.action.started += _=>SetUpWriting();
    }

    private void SetUpWriting()
    {
        OnStartWriting?.Invoke();
        StartCoroutine("EnableWriteCanvasWithDelay");
    }
    private IEnumerator EnableWriteCanvasWithDelay()
    {
        yield return new WaitForSeconds(timeToActivateMessageCanvas);
        messageCanvas.SetActive(true);
    }
}
