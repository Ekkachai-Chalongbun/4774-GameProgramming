using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 10f;
    [SerializeField] private float additionalSleepJumpTime = 10f;

    [SerializeField] private Animator animator;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;

    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    [SerializeField] private PlayerController player;

    public void TriggerJumpPad()
    {
        animator.SetTrigger("Jump");
        player.Jump(jumpPadForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerJumpPad();
        }
    }
}
