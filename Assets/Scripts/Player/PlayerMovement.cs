using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movementAction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movemenSpeed;

    private float horizontalAxis,verticalAxis;

    void Awake()
    {
        movementAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = movementAction.action.ReadValue<Vector2>().x;
        verticalAxis = movementAction.action.ReadValue<Vector2>().y;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalAxis,rb.velocity.y,verticalAxis) * movemenSpeed;
    }
}
