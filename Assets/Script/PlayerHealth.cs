using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHP;
    int currentHP;
    [SerializeField] HPScript hPScript;
    [SerializeField] Animator animator;
    bool hurt;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;

        hPScript.SetMaxHealth(maxHP);

        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (hurt)
        {
            transform.Translate(Vector2.right * -2f * Time.deltaTime);
        }
    }


    private void TakeDame(int eDamage)
    {
        currentHP -= eDamage;
        hPScript.setHealth(currentHP);

        animator.SetTrigger("Hurt");


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EAttack")
        {

            //rb2d.velocity= new Vector2(-10, rb2d.velocity.y);
            //rb2d.AddForce(Vector2.right * -100f, ForceMode2D.Force);
            StartCoroutine(Time_hurt());
            TakeDame(20);
        }
    }

    IEnumerator Time_hurt()
    {
        hurt = true;
        yield return new WaitForSeconds(1f);
        hurt = false;
    }
}
