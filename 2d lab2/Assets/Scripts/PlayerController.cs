using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float _moveInput;
    private CollectibleColor playerColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce((transform.up * jumpForce), ForceMode2D.Impulse);
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
            Destroy(collectibleController.gameObject);
        }
    }

    private void Update()
    {
        rb.velocity = new Vector2(_moveInput * moveSpeed, rb.velocity.y);
    }
}
