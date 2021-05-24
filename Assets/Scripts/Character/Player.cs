using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dice currentDice = null;

    Animator animator;
    private void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void PlayDieAnimation()
    {
        animator.SetTrigger("Die");
    }

    public int GetDamage()
    {
        return Random.Range(1, 7);
    }
}
