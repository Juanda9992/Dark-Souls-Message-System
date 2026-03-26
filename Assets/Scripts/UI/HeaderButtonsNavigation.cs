using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderButtonsNavigation : MonoBehaviour
{
    [SerializeField] private Button[] headerButtonsArray;
    [SerializeField] private GameObject[] panelsArray;

    void Awake()
    {
        if(headerButtonsArray.Length == 0)
        {
            return;
        }

        SetUpMenus();
    }
    public void SetUpMenus()
    {
        for(int i = 0; i<headerButtonsArray.Length;i++)
        {
            int index = i;

            headerButtonsArray[i].onClick.AddListener(()=>ToggleMenu(index));
        }

        headerButtonsArray[0].onClick.Invoke();
    }

    public void LoadItemsExternaly(Button[] buttonsToLoad,GameObject[] objectsToLoad)
    {
        headerButtonsArray = buttonsToLoad;
        panelsArray = objectsToLoad;

        SetUpMenus(); 
    }

    private void ToggleMenu(int index)
    {
        foreach(var panel in panelsArray)
        {
            panel.SetActive(false);
        }

        panelsArray[index].SetActive(true);
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
