using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int isGrounded = Animator.StringToHash("isGrounded");
    private static readonly int velocityX = Animator.StringToHash("xVelocity");

    public void SetAnimationParameter(Vector2 playerVelocity, bool groundState)
    {
        animator.SetBool(isGrounded, groundState);
        animator.SetFloat(velocityX, Mathf.Abs(playerVelocity.x));
    }
}
