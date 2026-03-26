
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsSectionHandleUI : MonoBehaviour
{
    [SerializeField] private RectTransform buttonsSectionParent, menusParent;
    [SerializeField] private Button buttonSectionPrefab;
    [SerializeField] private ButtonPhrase buttonPhrasePrefab;
    [SerializeField] private RectTransform sectionContainerPrefab;
    [SerializeField] private MessageConstructorUI messageConstructorUI;
    public void InstantiateSectionButton(MessageData.WordsClasificationContainer clasificationContainer)
    {
        Button instantiatedButton = Instantiate(buttonSectionPrefab, buttonsSectionParent);
        instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = clasificationContainer.wordClasificationTitle;
        RectTransform newSection = Instantiate<RectTransform>(sectionContainerPrefab, menusParent);


        for (int i = 0; i < clasificationContainer.wordCategoryArray.Length; i++)
        {
            ButtonPhrase buttonPhrase = Instantiate(buttonPhrasePrefab, newSection);
            buttonPhrase.SetUpButton(clasificationContainer.wordCategoryArray[i], messageConstructorUI);
        }
    }
}
