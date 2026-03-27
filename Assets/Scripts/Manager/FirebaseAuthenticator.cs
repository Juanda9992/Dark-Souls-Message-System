using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.Events;
public class FirebaseAuthenticator : MonoBehaviour
{
    [SerializeField] private UnityEvent OnAuthCompleted;
    private FirebaseAuth firebaseAuth;

    void Start()
    {
        firebaseAuth = FirebaseAuth.DefaultInstance;

        firebaseAuth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task=>
        {
            if (task.IsCompleted)
            {
                OnAuthCompleted?.Invoke();
            }
        });
    }
}
