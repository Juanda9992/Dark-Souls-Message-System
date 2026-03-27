using UnityEngine;

public class MessageObject : MonoBehaviour
{
    public string messageWritten;
    private MessageReaderUI _messageReaderUI;

    public void SetUpObject(string message,MessageReaderUI messageReaderUI)
    {
        _messageReaderUI = messageReaderUI;
        messageWritten = message;
    }
}
