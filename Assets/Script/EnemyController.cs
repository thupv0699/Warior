using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float leftMax;
    [SerializeField] float rightMax;

    private bool isFaceLeft = true;

    private enum State
    {
        idle,
        run,
        attack
    };

    private State state = State.idle;

    Rigidbody2D rb2d;

    Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFaceLeft)
        {
            if (transform.position.x < leftMax)
            {
                Flip();
                moveSpeed *= -1;
            }
            else
            {
                isFaceLeft = false;
            }
        }
        else
        {
            if(transform.position.x > rightMax)
            {
                Flip();
                moveSpeed *= -1;
            }
            else
            {
                isFaceLeft = true;
            }
        }

        rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

        StateSwitch();

    }
    private void StateSwitch()
    {
        if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon)
        {
            state = State.run;
        }

        anim.SetInteger("State", (int)state);
    }
    private void Flip()
    {
        isFaceLeft = !isFaceLeft;
        transform.Rotate(0f, 180, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Sword"){
            Debug.Log("get damage from sword");
        }
    }
}
