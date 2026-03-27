using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Firestore;
using UnityEngine;

public class MessageInstantiatingManager : MonoBehaviour
{
    [SerializeField] private MessageReaderUI messageReaderUI;
    [SerializeField] private MessageObjectInWorld messageObjectPrefab;

    public void InstantiateObjects(Dictionary<string, object> gatheredEntry)
    {
        float x = float.Parse(gatheredEntry["posX"].ToString());
        float y = float.Parse(gatheredEntry["posY"].ToString());
        float z = float.Parse(gatheredEntry["posZ"].ToString());
        float rot = float.Parse(gatheredEntry["rotY"].ToString());
        Vector3 coordinates = new Vector3(x, y, z);

        MessageObjectInWorld obj = Instantiate(messageObjectPrefab, coordinates, Quaternion.Euler(0,rot,0));

        obj.SetUpObject(gatheredEntry["text"].ToString(), messageReaderUI);
    }


    public void CreateMessageLocally(Vector3 position,float yRotation,string message)
    {
        MessageObjectInWorld obj = Instantiate(messageObjectPrefab, position, Quaternion.Euler(0,yRotation,0));
    
        obj.SetUpObject(message,messageReaderUI);
    }
}
