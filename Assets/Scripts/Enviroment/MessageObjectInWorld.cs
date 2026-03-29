using UnityEngine;

public class MessageObjectInWorld : MonoBehaviour
{
    public string messageWritten;
    [SerializeField] private GameObject[] runesObjArray;
    public GameObject particlesObj;
    private MessageReaderUI _messageReaderUI;

    void OnEnable()
    {
        foreach(var rune in runesObjArray)
        {
            rune.SetActive(false);
        }

        runesObjArray[Random.Range(0,runesObjArray.Length)].SetActive(true);
    }
    public void SetUpObject(string message,MessageReaderUI messageReaderUI)
    {
        _messageReaderUI = messageReaderUI;
        messageWritten = message;
    }
}
