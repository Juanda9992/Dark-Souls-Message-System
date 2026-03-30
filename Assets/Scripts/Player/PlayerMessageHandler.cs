using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMessageHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnStartWriting;
    [SerializeField] private GameObject interactCanvas;
    [SerializeField] private InputActionReference writeAction, readAction;
    [SerializeField] private MessageConstructorUI messageConstructorUI;
    [SerializeField] private MessageReaderUI messageReaderUI;
    [SerializeField] private MessageCooldownManager messageCooldownManager;

    private MessageObjectInWorld messageObject;
    private float timeToActivateMessageCanvas = 2f;
    void Awake()
    {
        writeAction.action.Enable();
        readAction.action.Enable();
        writeAction.action.started += _ => SetUpWriting();
        readAction.action.started += _ => ReadMessage();
        CursorManager.HideCursor();
    }

    private void SetUpWriting()
    {
        if(!messageCooldownManager.canSendMessage)
        {
            messageCooldownManager.ShowCooldownEnabledLabel();
            return;
        }
        OnStartWriting?.Invoke();
        StartCoroutine("EnableWriteCanvasWithDelay");
    }
    private IEnumerator EnableWriteCanvasWithDelay()
    {
        yield return new WaitForSeconds(timeToActivateMessageCanvas);
        messageConstructorUI.OnShowPanel();
    }

    private void ReadMessage()
    {
        if (messageObject != null)
        {
            messageObject.particlesObj.SetActive(false);
            messageReaderUI.OpenMessage(messageObject.messageWritten);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MessageObjectInWorld>(out MessageObjectInWorld _messageObject))
        {
            messageObject = _messageObject;
            interactCanvas.SetActive(true);
            interactCanvas.transform.position = messageObject.transform.position + (Vector3.up * 2);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MessageObjectInWorld>(out messageObject))
        {
            messageObject = null;
            interactCanvas.gameObject.SetActive(false);
        }
    }
}
