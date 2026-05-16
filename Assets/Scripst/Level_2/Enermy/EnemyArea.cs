using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{

    public bool chasingArea = false; 
    public Transform player;
    [SerializeField] float enermySpeed;
    public EnemyVision enemyVision;
    public EnemyWayPoint enemyWayPoint;
    public Enemy enemyAnim;
  
    void Start()
    {
        chasingArea = false; 
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
         if(enemyVision.isChasing || chasingArea)
        {
            enemyWayPoint.isWalk = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, enermySpeed * Time.deltaTime);
        }
        if(player.position.x > transform.position.x)
            transform.localScale = new Vector3(1,1,1);
        else
            transform.localScale = new Vector3(-1,1,1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enemyVision.isChasing)
        {
            if(other.CompareTag("Player"))
        {
           chasingArea = true;
        }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           chasingArea = false;
           enemyVision.isChasing = false;
           enemyWayPoint.isWalk = true;
           enemyAnim.SetRun(false);
           
           
        }
    }
}
