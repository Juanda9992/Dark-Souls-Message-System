using Juanda.SoundSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageReaderUI : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closePanel;

    void Awake()
    {
        closePanel.onClick.AddListener(OnPanelClose);
    }
    public void OpenMessage(string text)
    {
        CursorManager.ShowCursor();
        SoundManager.instance.PlaySoundByName("MenuOpen");
        messagePanel.SetActive(true);
        messageText.text = text;
    }

    public void OnPanelClose()
    {
        SoundManager.instance.PlaySoundByName("MenuOpen");
        CursorManager.HideCursor();
        messagePanel.SetActive(false);
    }
}
