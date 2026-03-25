using UnityEngine;

[CreateAssetMenu(fileName = "Message Data")]
public class MessageData : ScriptableObject
{
    public string[] templatesArray;
    public string[] wordsArray;
    public string[] conjunctionsArray;

    public WordsClasificationContainer[] wordsClasificationsArray;

    [SerializeField, TextArea] private string textToParse;
    [SerializeField] private int arrayIndex;
    [ContextMenu("Set up data")]
    private void SetUpData()
    {
        string[] splittedWords = textToParse.Split('\n');

        switch (arrayIndex)
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
    [ContextMenu("Parse Catewgory Words")]
    private void ParseCategoryWords()
    {
        foreach(var category in wordsClasificationsArray)
        {
            category.ParseData();
        }
    }
    [System.Serializable]
    public class WordsClasificationContainer
    {
        public string wordClasificationTitle;
        public string[] wordCategoryArray;

        [TextArea] private string textToParse;

        public void ParseData()
        {
            string[] splittedWords = textToParse.Split('\t');
            wordCategoryArray = splittedWords;
        }
    }
}
