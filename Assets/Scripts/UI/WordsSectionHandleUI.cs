using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsSectionHandleUI : MonoBehaviour
{
    [SerializeField] private RectTransform rootButtonSection;
    [SerializeField] private RectTransform buttonsSectionParent,menusParent;
    [SerializeField] private Button buttonPrefab;

    public void InstantiateSectionButton(string sectionName)
    {
        Button instantiatedButton = Instantiate(buttonPrefab,buttonsSectionParent);
        instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = sectionName;
        RectTransform emptySection = Instantiate<RectTransform>(new GameObject(sectionName).AddComponent<RectTransform>(),menusParent);

        emptySection.anchorMin = new Vector2(0,0);
        emptySection.anchorMax = new Vector2(1,1);
        emptySection.offsetMin = Vector2.zero;
        emptySection.offsetMax = Vector2.zero;
    
        LayoutRebuilder.ForceRebuildLayoutImmediate(rootButtonSection);
    }
}
