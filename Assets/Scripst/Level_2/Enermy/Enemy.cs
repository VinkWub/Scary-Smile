using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hitBox;
    public Animator EnemyAnimator;

    bool isPlayerInside = false;
    bool isAttacking = false;
    [SerializeField] public float deleyHit;
    [SerializeField] public float beforeHit;
    [SerializeField] public float afterHit;



    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        hitBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInside = true;

            if(!isAttacking)
            {
                StartCoroutine(AttackDelay());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInside = false;
            hitBox.SetActive(false);
        }
    }

    public void SetRun(bool isRun)
    {
        if(EnemyAnimator != null)
        {
            EnemyAnimator.SetBool("run", isRun);
            EnemyAnimator.SetBool("walk", !isRun);
        }
    }

    public void PlayAttack()
{
    EnemyAnimator.SetTrigger("Attack");
}

    IEnumerator AttackDelay()
{
    isAttacking = true;

    while(isPlayerInside)
    {
        yield return new WaitForSeconds(beforeHit);

        if(!isPlayerInside) break;

        PlayAttack();

        hitBox.SetActive(true);

        yield return new WaitForSeconds(deleyHit);

        hitBox.SetActive(false);

        yield return new WaitForSeconds(afterHit);
    }

    hitBox.SetActive(false);
    isAttacking = false;
}
}