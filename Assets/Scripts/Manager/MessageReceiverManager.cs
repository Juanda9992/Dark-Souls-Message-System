using UnityEngine;
using Firebase.Firestore;
using System.Linq;
using Firebase.Extensions;
public class MessageReceiverManager : MonoBehaviour
{
    [SerializeField] private MessageInstantiatingManager messageInstantiatingManager;
    private FirebaseFirestore db;
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
    }
    [ContextMenu("Check Database entries")]
    public void GetMessages()
    {
        db.Collection("messages").GetSnapshotAsync().ContinueWithOnMainThread(task=>
        {
            foreach(var doc in task.Result.Documents)
            {
                messageInstantiatingManager.InstantiateObjects(doc.ToDictionary());
            }
        });
    }
}
