using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
public class MessageSenderManager : MonoBehaviour
{
    [SerializeField] private MessageInstantiatingManager messageInstantiatingManager;
    [SerializeField] private Transform playerTransform;
    private FirebaseFirestore db;
    // Start is called before the first frame update
    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
    }
    public void SendPlayerMessage(string messageCreated)
    {
        Vector3 playerForwardPos = CheckGroundPos();
        Dictionary<string, object> message = new Dictionary<string, object>()
        {
            {"text",messageCreated},
            {"posX", playerForwardPos.x},
            {"posY", playerForwardPos.y},
            {"posZ", playerForwardPos.z},
            {"rotY", playerTransform.rotation.eulerAngles.y},
        };

        db.Collection("messages").AddAsync(message);
        messageInstantiatingManager.CreateMessageLocally(playerForwardPos,playerTransform.rotation.eulerAngles.y, messageCreated);
    }
    [ContextMenu("Check Ground Pos")]
    private Vector3 CheckGroundPos()
    {
        Vector3 playerForwardPos = playerTransform.position + playerTransform.forward.normalized;
        RaycastHit hit;

        Vector3 groundPos = Vector3.zero;
        if (Physics.Raycast(playerForwardPos, Vector3.down, out hit))
        {
            groundPos = hit.point;
        }
        return groundPos;
    }
}
