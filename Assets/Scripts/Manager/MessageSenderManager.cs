using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
public class MessageSenderManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private FirebaseFirestore db;
    // Start is called before the first frame update
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
    }
    public void SendPlayerMessage(string messageCreated)
    {
        Dictionary<string,object> message = new Dictionary<string, object>()
        {
            {"text",messageCreated},
            {"posX", playerTransform.position.x},
            {"posY", playerTransform.position.y},
            {"posZ", playerTransform.position.z},
        };

        db.Collection("messages").AddAsync(message);
    }
}
