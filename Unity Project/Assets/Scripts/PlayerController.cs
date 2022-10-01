using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.05f;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private float coyoteCount;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private PlayerAudioController audioController;
    private bool isGrounded;
    private bool groundState;
    private float _moveInput;
    private CollectibleColor playerColor;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(_moveInput * moveSpeed, rb.velocity.y);
        CheckGround();
        SetAnimParameter();
        SpriteDirection();
        CheckCoyotetime();
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            TryJumpFunction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectibleController collectibleController))
        {
            CollectibleColor playerColor = collectibleController.color;

            switch (playerColor)
            {
                case CollectibleColor.Red:
                    spriteRenderer.color = Color.red;
                    break;
                case CollectibleColor.Green:
                    spriteRenderer.color = Color.green;
                    break;
                case CollectibleColor.Blue:
                    spriteRenderer.color = Color.blue;
                    break;
            }
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Finish"))
        {
            gameManager.LoadNextLevel();
        }

        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            TakeDamage();
        }
    }

    private void SpriteDirection()
    {
        if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void SetAnimParameter()
    {
        animationController.SetAnimationParameter(rb.velocity, isGrounded);
    }

    private void CheckGround()
    {
        var playerColliderBounds = playerCollider.bounds;

        var raycastHit = Physics2D.BoxCast(playerColliderBounds.center,
            playerColliderBounds.size, 0f, Vector2.down, groundCheckDistance, groundLayer);

        isGrounded = raycastHit.collider != null;
    }

    private void TakeDamage()
    {
        gameManager.ProcessPlayerDeath();
    }

    public void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        coyoteCount = 0f;
    }

    private void TryJumpFunction()
    {
        if (!isGrounded && coyoteCount <= 0f) return;

        Jump(jumpForce);
        audioController.PlayJumpSound();
    }

    private void CheckCoyotetime()
    {
        if (isGrounded)
        {
            coyoteCount = coyoteTime;
        }
        else
        {
            coyoteCount -= Time.deltaTime;
        }
    }

    private void OnQuit(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.LoadMenu();
        }
    }
}
