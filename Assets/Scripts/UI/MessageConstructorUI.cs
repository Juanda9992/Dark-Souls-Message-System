using UnityEngine;

public class MessageConstructorUI : MonoBehaviour
{
    [SerializeField] private RectTransform templatesParent, wordsParent, conjunctionsPanel;
    [SerializeField] private MessageData phrasesContainer;

    [SerializeField] private ButtonPhrase buttonPhrasePrefab;

    void Awake()
    {
        SetUpUIButtons();
    }

    private void SetUpUIButtons()
    {
        for(int i = 0; i< phrasesContainer.templatesArray.Length;i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab,templatesParent);
            instantiatedButton.SetUpButton(phrasesContainer.templatesArray[i],this);
        }
        for(int i = 0; i< phrasesContainer.wordsArray.Length;i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab,wordsParent);
            instantiatedButton.SetUpButton(phrasesContainer.wordsArray[i],this);
        }
        for(int i = 0; i< phrasesContainer.conjunctionsArray.Length;i++)
        {
            ButtonPhrase instantiatedButton = Instantiate(buttonPhrasePrefab,conjunctionsPanel);
            instantiatedButton.SetUpButton(phrasesContainer.conjunctionsArray[i],this);
        }
    }
}
