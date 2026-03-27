using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMessageHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent OnStartWriting;
    [SerializeField] private InputActionReference writeAction,readAction;
    [SerializeField] private MessageConstructorUI messageConstructorUI;
    [SerializeField] private MessageReaderUI messageReaderUI;

    private MessageObject messageObject;
    private float timeToActivateMessageCanvas = 2f;
    void Awake()
    {
        writeAction.action.Enable();
        readAction.action.Enable();
        writeAction.action.started += _=>SetUpWriting();
        readAction.action.started += _=>ReadMessage();
        CursorManager.HideCursor();
    }

    private void SetUpWriting()
    {
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
        if(messageObject != null)
        {
            messageReaderUI.OpenMessage(messageObject.messageWritten);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<MessageObject>(out MessageObject _messageObject))
        {
            messageObject = _messageObject;
            Debug.Log("Encountered Object");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<MessageObject>(out messageObject))
        {
            messageObject = null;       
        }
    }
}
