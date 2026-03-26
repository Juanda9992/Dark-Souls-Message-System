using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageConstructorUI : MonoBehaviour
{
    [SerializeField] private RectTransform templatesParent, wordsParent, conjunctionsPanel;
    [SerializeField] private MessageData phrasesContainer;
    [SerializeField] private WordsSectionHandleUI wordsSectionHandleUI;

    [SerializeField] private ButtonPhrase buttonPhrasePrefab;

    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private List<string> stringsList;

    [Header("Control Elements")]
    [SerializeField] private Toggle editingSecondPhraseToggle;
    [SerializeField] private Button deleteMessage;
    [SerializeField] private Button sendMessage;
    private bool editingSecondPhrase => editingSecondPhraseToggle.isOn;
    private string messageCreated;
    
    void Awake()
    {
        SetUpUIButtons();
        messageText.text = messageCreated;
        stringsList = new List<string>(new string[5]);
    }

    private void SetUpUIButtons()
    {
        for (int i = 0; i < phrasesContainer.templatesArray.Length; i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab, templatesParent);
            instantiatedButton.SetUpButton(phrasesContainer.templatesArray[i], this, PhraseCategory.Template);
        }
        for (int i = 0; i < phrasesContainer.conjunctionsArray.Length; i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab, conjunctionsPanel);
            instantiatedButton.SetUpButton(phrasesContainer.conjunctionsArray[i], this, PhraseCategory.Conjunction);
        }

        for (int i = 0; i < phrasesContainer.wordsClasificationsArray.Length; i++)
        {
            wordsSectionHandleUI.InstantiateSectionButton(phrasesContainer.wordsClasificationsArray[i]);
        }

        deleteMessage.onClick.AddListener(DeletePhrase);

        wordsSectionHandleUI.SetUpMenusExternally();
    }

    public void AddToWord(string word, PhraseCategory phraseCategory)
    {
        if (phraseCategory == PhraseCategory.Template)
        {
            if (!editingSecondPhrase)
            {
                stringsList[0] = word;
            }
            else
            {
                stringsList[3] = word;
            }
        }
        else if (phraseCategory == PhraseCategory.Word)
        {
            if (!editingSecondPhrase)
            {
                stringsList[1] = word;
            }
            else
            {
                stringsList[4] = word;
            }
        }
        else if (phraseCategory == PhraseCategory.Conjunction)
        {
            stringsList[2] = word;
        }

        ParseWordToText();
    }

    private void ParseWordToText()
    {
        messageCreated = stringsList[0];

        string secondPhrase = string.Empty;
        if (!string.IsNullOrEmpty(stringsList[1]))
        {
            messageCreated = stringsList[0].Replace("****", stringsList[1]);
        }
        if (!string.IsNullOrEmpty(stringsList[2]))
        {
            messageCreated += " " + stringsList[2];
        }
        if (!string.IsNullOrEmpty(stringsList[3]))
        {
            secondPhrase = stringsList[3];
        }
        if (!string.IsNullOrEmpty(stringsList[4]))
        {
            secondPhrase = secondPhrase.Replace("****", stringsList[4]);
        }
        messageText.text = messageCreated + " " + secondPhrase;
    }

    private void DeletePhrase()
    {
        for(int i = 0; i< stringsList.Count;i++)
        {
            stringsList[i] = string.Empty;   
        }

        ParseWordToText();
    }
}

public enum PhraseCategory
{
    Template,
    Word,
    Conjunction
}
