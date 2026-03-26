
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsSectionHandleUI : MonoBehaviour
{
    [SerializeField] private RectTransform buttonsSectionParent, menusParent;
    [SerializeField] private Button buttonSectionPrefab;
    [SerializeField] private ButtonPhrase buttonPhrasePrefab;
    [SerializeField] private WordCategoryContainerUI sectionContainerPrefab;
    [SerializeField] private MessageConstructorUI messageConstructorUI;

    [SerializeField] private HeaderButtonsNavigation wordSectionnavigation;

    private List<Button> createdButtons = new List<Button>();
    private List<GameObject> createdMenus = new List<GameObject>();
    public void InstantiateSectionButton(MessageData.WordsClasificationContainer clasificationContainer)
    {
        Button instantiatedButton = Instantiate(buttonSectionPrefab, buttonsSectionParent);
        instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = clasificationContainer.wordClasificationTitle;
        WordCategoryContainerUI newSection = Instantiate<WordCategoryContainerUI>(sectionContainerPrefab, menusParent);


        for (int i = 0; i < clasificationContainer.wordCategoryArray.Length; i++)
        {
            ButtonPhrase buttonPhrase = Instantiate(buttonPhrasePrefab, newSection.childTransform);
            buttonPhrase.SetUpButton(clasificationContainer.wordCategoryArray[i], messageConstructorUI);
        }

        createdButtons.Add(instantiatedButton);
        createdMenus.Add(newSection.gameObject);
    }

    public void SetUpMenusExternally()
    {
        wordSectionnavigation.LoadItemsExternaly(createdButtons.ToArray(),createdMenus.ToArray());
    }
}
