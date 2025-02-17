using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // References
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    // Movement
    public float moveSpeed = 5f;
    private Vector2 moveDir;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nh?n input t? bàn phím
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        // Ki?m tra t?c ?? c?a Rigidbody ?? b?t/t?t Animation
        bool isMoving = rb.velocity.magnitude > 0.1f;
        animator.SetBool("Move", isMoving);

        // X? lý h??ng quay c?a nhân v?t
        if (moveDir.x != 0)
        {
            spriteRenderer.flipX = moveDir.x < 0;
        }
    }

    void FixedUpdate()
    {
        // C?p nh?t v?n t?c cho Rigidbody ?? di chuy?n nhân v?t
        rb.velocity = moveDir * moveSpeed;
    }
}
