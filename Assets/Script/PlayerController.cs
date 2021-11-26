using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    Transform player;
    Collider2D groundCheck;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] int playerDamage;
    [SerializeField] LayerMask groundLayer;

    private enum State { idle, run, jump, falling, hurt };
    private State state = State.idle;

    float keyMove;
    float keyJump;

    private bool isFaceRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();

        bc2d = GetComponent<BoxCollider2D>();

        player = GetComponent<Transform>();

        groundCheck = GetComponent<Collider2D>();

    }
    private void FixedUpdate()
    {
        PlayerMoving();

        StateSwitch();
    }

    private void PlayerMoving()
    {
        keyMove = Input.GetAxisRaw("Horizontal");
        keyJump = Input.GetAxisRaw("Vertical");

        if (keyMove != 0)
        {
            if (keyMove > 0)
            {
                if (!isFaceRight)
                {
                    Flip();
                }
            }
            else if (keyMove < 0)
            {
                if (isFaceRight)
                {
                    Flip();
                }
            }
            rb2d.velocity = new Vector2(moveSpeed * keyMove, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }

        if (keyJump != 0 && groundCheck.IsTouchingLayers(groundLayer))
        {
            state = State.jump;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }

    private void StateSwitch()
    {
        if (state == State.jump)
        {
            if (rb2d.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (groundCheck.IsTouchingLayers(groundLayer))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }

        animator.SetInteger("State", (int)state);
    }

    private void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.Rotate(0, 180, 0);
    }
}
