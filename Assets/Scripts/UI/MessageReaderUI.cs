using TMPro;
using UnityEngine;

public class MessageReaderUI : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;
    public void OpenMessage(string text)
    {
        CursorManager.ShowCursor();

        messagePanel.SetActive(true);
        messageText.text = text;
    }
}
