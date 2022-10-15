using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private enum MovementState { idle, running, jumping }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Jumping logic
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        // move right
        if (dirX > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        // move left
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        // idle
        else
        {
            state = MovementState.idle;
        }

        // jumping
        if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
