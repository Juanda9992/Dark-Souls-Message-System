using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
public class FirebaseAuthenticator : MonoBehaviour
{
    private FirebaseAuth firebaseAuth;

    void Start()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;

        firebaseAuth.SignInAnonymouslyAsync().ContinueWith(task=>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Login Ok");
            }
        });
    }
}
