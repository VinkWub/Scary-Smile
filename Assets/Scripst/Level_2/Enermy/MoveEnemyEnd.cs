using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyEnd : MonoBehaviour
{
    private Animator EnemyAnimator;
    public Transform wayPointEnd;
    public GameObject enemyEnd;

    void Start()
    {
        EnemyAnimator = enemyEnd.GetComponent<Animator>();

        if(EnemyAnimator != null)
            EnemyAnimator.SetBool("Idle2", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(EnemyAnimator != null)
                EnemyAnimator.SetBool("Idle2", true);

            enemyEnd.transform.position = wayPointEnd.position;
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}