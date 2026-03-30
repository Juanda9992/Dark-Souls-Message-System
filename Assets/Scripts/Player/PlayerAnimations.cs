using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private Animator playerAnimator;

    public void SetPlayerWalkingState(bool isMoving)
    {
        playerAnimator.SetFloat("MovementInput",isMoving ? 1:0);
    }
    public void SetPlayerWriting(bool writing)
    {
        playerCollider.height = writing ? 0.2f : 2;
        playerAnimator.SetBool("Writing",writing);
    }
}
