using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float leftMax;
    [SerializeField] float rightMax;

    private bool isFaceLeft = true;

    HPScript hq;
    private enum State
    {
        idle,
        run,
        attack
    };

    private State state = State.idle;


    Animator anim;
    BoxCollider2D b2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        b2d = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFaceLeft)
        {
            //Nếu vị trí của Enemy < left max thì quay đầu enemy
            if (transform.position.x < leftMax)
            {
                Flip();
            }
        }
        else
        {
            if (transform.position.x > rightMax)
            {
                Flip();
            }
        }

        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        StateSwitch();

    }
    private void StateSwitch()
    {
        //nếu nhân nhật di chuyển thì chuyển sang state đi
        if (transform.position.x != 0)
        {
            state = State.run;
        }
        anim.SetInteger("State", (int)state);
    }
    private void Flip()
    {
        //thực hiện quay đầu
        isFaceLeft = !isFaceLeft;
        transform.Rotate(0f, 180, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            //nếu chạm vào tag Sword thì destroy game object(death)
            Destroy(gameObject);
        }
    }
}
