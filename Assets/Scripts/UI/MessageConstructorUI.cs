using UnityEngine;

public class MessageConstructorUI : MonoBehaviour
{
    [SerializeField] private RectTransform templatesParent, wordsParent, conjunctionsPanel;
    [SerializeField] private MessageData phrasesContainer;
    [SerializeField] private WordsSectionHandleUI wordsSectionHandleUI;

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
}

public enum PhraseCategory
{
    Template,
    Word,
    Conjunction
}
