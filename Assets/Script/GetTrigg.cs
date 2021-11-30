using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrigg : MonoBehaviour
{
    BoxCollider2D b2d;
    Animator animator;
    void Start()
    {
        b2d = GetComponent<BoxCollider2D>();
        animator =GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("attack her");
        animator.SetTrigger("EAttack");
    }
}
