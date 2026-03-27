using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private InputActionReference movementAction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movemenSpeed;
    [SerializeField] private float rotSpeed;

    [SerializeField] private Transform camTransform;

    [SerializeField] private Transform visualModel;
    private float horizontalAxis, verticalAxis;
    private bool canMove = true;

    void Awake()
    {
        movementAction.action.Enable();
        CursorManager.HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            horizontalAxis = 0;
            verticalAxis = 0;
            return;
        }
        horizontalAxis = movementAction.action.ReadValue<Vector2>().x;
        verticalAxis = movementAction.action.ReadValue<Vector2>().y;

        _playerAnimations.SetPlayerWalkingState(horizontalAxis != 0 || verticalAxis != 0);


    }
    void FixedUpdate()
    {
        Vector3 movement = horizontalAxis * camTransform.right + verticalAxis * camTransform.forward;
        movement.y = 0;
        if (movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement.normalized);
            visualModel.localRotation = Quaternion.Slerp(visualModel.localRotation, rotation, rotSpeed * Time.fixedDeltaTime);
        }
        rb.velocity = movement * movemenSpeed;
    }

    public void SetMovementEnabled(bool enable)
    {
        canMove = enable;
    }
}
