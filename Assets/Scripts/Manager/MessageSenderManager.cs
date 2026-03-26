using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
public class MessageSenderManager : MonoBehaviour
{
    private FirebaseFirestore db;
    // Start is called before the first frame update
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
    }
    [ContextMenu("Send Message")]
    public void SendMessage()
    {
        Dictionary<string,object> message = new Dictionary<string, object>()
        {
            {"text","Hola, Mi Paulita es Hermosa"},
            {"posX", 10f},
            {"posY", 20f},
            {"posZ", 50f},
        };

        db.Collection("messages").AddAsync(message);
    }
}
