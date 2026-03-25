using UnityEngine;
using Firebase.Firestore;
public class MessageReceiverManager : MonoBehaviour
{
    private FirebaseFirestore db;
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
    }
    [ContextMenu("Check Database entries")]
    public void GetMessages()
    {
        db.Collection("messages").GetSnapshotAsync().ContinueWith(task=>
        {
            foreach(var doc in task.Result.Documents)
            {
                Debug.Log(doc.GetValue<string>("text"));
            }
        });
    }
}
