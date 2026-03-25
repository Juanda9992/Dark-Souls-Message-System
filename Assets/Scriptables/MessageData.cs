using UnityEngine;

[CreateAssetMenu(fileName = "Message Data")]
public class MessageData : ScriptableObject
{
    public string[] templatesArray;
    public string[] wordsArray;
    public string[] conjunctionsArray;

    [SerializeField,TextArea] private string textToParse;
    [SerializeField] private int arrayIndex;
    [ContextMenu("Set up data")]
    private void SetUpData()
    {
        string[] splittedWords = textToParse.Split('\n');
        
        switch(arrayIndex)
        {
            case 0:
                templatesArray = splittedWords;
                break;
            case 1:
                wordsArray = splittedWords;
                break;
            case 2:
                conjunctionsArray = splittedWords;
                break;
        }
    }
}
