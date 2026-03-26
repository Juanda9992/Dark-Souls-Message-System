using System;
using TMPro;
using UnityEngine;

public class MessageConstructorUI : MonoBehaviour
{
    [SerializeField] private RectTransform templatesParent, wordsParent, conjunctionsPanel;
    [SerializeField] private MessageData phrasesContainer;
    [SerializeField] private WordsSectionHandleUI wordsSectionHandleUI;

    [SerializeField] private ButtonPhrase buttonPhrasePrefab;

    [SerializeField] private TextMeshProUGUI messageText;
    private string messageCreated;

    private string lastTemplate,lastWord;
    void Awake()
    {
        SetUpUIButtons();
        messageText.text = messageCreated;
    }

    private void SetUpUIButtons()
    {
        for(int i = 0; i< phrasesContainer.templatesArray.Length;i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab,templatesParent);
            instantiatedButton.SetUpButton(phrasesContainer.templatesArray[i],this,PhraseCategory.Template);
        }
        for(int i = 0; i< phrasesContainer.conjunctionsArray.Length;i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab,conjunctionsPanel);
            instantiatedButton.SetUpButton(phrasesContainer.conjunctionsArray[i],this,PhraseCategory.Conjunction);
        }

        for(int i = 0; i< phrasesContainer.wordsClasificationsArray.Length;i++)
        {
            wordsSectionHandleUI.InstantiateSectionButton(phrasesContainer.wordsClasificationsArray[i]);
        }

        wordsSectionHandleUI.SetUpMenusExternally();
    }

    public void AddToWord(string word, PhraseCategory phraseCategory)
    {
        if(phraseCategory == PhraseCategory.Template)
        {
            messageCreated = word;
            lastTemplate = word;

            if(!String.IsNullOrEmpty(lastWord))
            {
                messageCreated = word.Replace("****",lastWord);
            }
        }
        else if(phraseCategory == PhraseCategory.Word)
        {
            messageCreated = messageCreated.Replace("****",word);
            lastWord = word;

            if(!string.IsNullOrEmpty(lastTemplate))
            {
                messageCreated = lastTemplate.Replace("****",lastWord);
                
            }
        }

        messageText.text = messageCreated;
    }
}

public enum PhraseCategory
{
    Template,
    Word,
    Conjunction
}
