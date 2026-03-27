using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public void SetPlayerWalkingState(bool isMoving)
    {
        playerAnimator.SetFloat("MovementInput",isMoving ? 1:0);
    }
}
