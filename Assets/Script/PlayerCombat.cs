using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] int playerDamage;

    [SerializeField] Transform attackPoint;

    [SerializeField] float attackRange=0.5f;

    [SerializeField] LayerMask enemyLayer;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            PlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemyHit)
        {
            Debug.Log("Hit enemy" + enemy.name);
        }
    }
}
