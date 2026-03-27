using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObjectInWorld : MonoBehaviour
{
    public string messageWritten;
    private MessageReaderUI _messageReaderUI;

    public void SetUpObject(string message,MessageReaderUI messageReaderUI)
    {
        _messageReaderUI = messageReaderUI;
        messageWritten = message;
    }
}
