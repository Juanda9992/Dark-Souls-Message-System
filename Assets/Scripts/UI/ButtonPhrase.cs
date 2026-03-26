using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPhrase : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private PhraseCategory _phraseCategory;
    private MessageConstructorUI _messageConstructorUI;

    void Awake()
    {
        _button.onClick.AddListener(ConstructPhrase);
    }
    public void SetUpButton(string buttonContent,MessageConstructorUI messageConstructorUI, PhraseCategory phraseCategory)
    {
        buttonText.text = buttonContent.TrimEnd();
        _messageConstructorUI = messageConstructorUI;
        _phraseCategory = phraseCategory;
    }

    private void ConstructPhrase()
    {
        Debug.Log(_phraseCategory);
    }
}
