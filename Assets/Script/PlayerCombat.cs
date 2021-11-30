using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] int playerDamage;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("Attack");
        }
    }
}
