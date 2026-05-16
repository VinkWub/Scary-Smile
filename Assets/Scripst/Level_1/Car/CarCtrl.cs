using System.Collections;
using UnityEngine;

public class CarCtrl : MonoBehaviour
{
    public Transform[] wayPoint;

    [Header("Speed")]
    [SerializeField] private float maxCarSpeed = 6f;

    [Header("Physics Stop")]
    [SerializeField] private float acceleration = 4f;
    [SerializeField] private float brakePower = 6f;

    [Header("Other")]
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private bool destroyCar;

    private float currentSpeed = 0f;
    private int currentPoint = 0;
    private bool isWaiting = false;
    private bool isReturn = false;

    private Rigidbody2D carRigid;
    private Animator carAnimator;

    void Start()
    {
        carRigid = GetComponent<Rigidbody2D>();
        carAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (wayPoint.Length == 0 || isWaiting)
            return;

        Transform target = wayPoint[currentPoint];
        float distance = Vector2.Distance(transform.position, target.position);


        float brakingSpeed = Mathf.Sqrt(2f * brakePower * distance);

        float targetSpeed = Mathf.Min(maxCarSpeed, brakingSpeed);

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            acceleration * Time.deltaTime
        );


        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            currentSpeed * Time.deltaTime
        );

        carAnimator.SetFloat("speedCar", currentSpeed);
        carAnimator.speed = Mathf.Clamp(currentSpeed / maxCarSpeed, 0f, 1f);
        Vector2 dir = target.position - transform.position;
        if (Mathf.Abs(dir.x) > 0.01f)
            transform.localScale = new Vector3(dir.x > 0 ? 1 : -1, 1, 1);

        if (distance < 0.02f && currentSpeed < 0.05f)
        {
            transform.position = target.position;
            currentSpeed = 0f;
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        if (currentPoint == wayPoint.Length - 1 && !isReturn)
        {
            isReturn = true;
            currentPoint--;
        }
        else if (currentPoint == 0 && isReturn)
        {
            if (destroyCar)
                Destroy(gameObject);
            else
                enabled = false;

            yield break;
        }
        else
        {
            currentPoint += isReturn ? -1 : 1;
        }

        isWaiting = false;
    }
}