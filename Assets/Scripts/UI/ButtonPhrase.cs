using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonPhrase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    private MessageConstructorUI _messageConstructorUI;
    public void SetUpButton(string buttonContent,MessageConstructorUI messageConstructorUI  )
    {
        buttonText.text = buttonContent;
        _messageConstructorUI = messageConstructorUI;
    }
}
