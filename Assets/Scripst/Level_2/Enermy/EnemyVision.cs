using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public bool isChasing = false;
    public EnemyArea enemyArea;
    public Enemy enemyAnim;

    void Start()
    {
       isChasing = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isChasing = true;
            enemyAnim.SetRun(true);
        }
    }

}
