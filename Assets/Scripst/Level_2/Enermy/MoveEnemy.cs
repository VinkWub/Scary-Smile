using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnermy : MonoBehaviour
{
    public Transform[] wayPoints;
    [SerializeField] private float speed;
    [SerializeField] private float delay;

    private bool canMove = false;
    private int currentPoint = 0;

    void Update()
    {
        if(!canMove) return;

        Transform target = wayPoints[currentPoint];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint++;

            if(currentPoint >= wayPoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(StartMove());
        }
    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}