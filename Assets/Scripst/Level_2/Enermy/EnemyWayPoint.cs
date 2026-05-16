using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPoint : MonoBehaviour
{
    public Transform[] wayPoints;
    [SerializeField] public float walkSpeed;
    public bool isWalk = false;
    int currentPoint = 0;
    public EnemyArea enemyArea;
    void Start()
    {
        isWalk = false;
    }
    void Update()
    {
        if(isWalk && !enemyArea.chasingArea && !enemyArea.enemyVision.isChasing)
        {
            Move();
        }
    }
    void Move()
    {
        Transform target = wayPoints[currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, target.position);
        
            if(distance < 0.1f)
        {
            currentPoint++;
            if(currentPoint >= wayPoints.Length)
            {
                currentPoint = 0;
            }
        }
        Vector2 dir = target.position - transform.position;
        if (Mathf.Abs(dir.x) > 0.01f)
            transform.localScale = new Vector3(dir.x > 0 ? 1 : -1, 1, 1);
        
    }
}
