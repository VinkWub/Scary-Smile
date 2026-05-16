using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class FinalPoint : MonoBehaviour
{
    public Light2D flashlightFinal;
    public Light2D oldFlashlight;
    public GameObject[] objectsToDestroy;
    private Animator playerAnimator;

    public bool turnOff = false;

    public Transform wayPointFinal;
    public Transform wayPointEnd;
    [SerializeField] private float finalSpeed;
    [SerializeField] private float EndSpeed;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        // flashlight = FindObjectOfType<Light2D>();
    }

    void Update()
    {
        if(turnOff)
        {
            oldFlashlight.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Final_Point"))
        {
            if(flashlightFinal != null)
            {
                flashlightFinal.enabled = true;
                turnOff = true;
            }

            foreach(GameObject obj in objectsToDestroy)
            {
                Destroy(obj);
            }

            StartCoroutine(Cutscene());
        }
    }
    IEnumerator Cutscene()
    {  
            playerAnimator.SetFloat("speed", 1);
            while(Vector2.Distance(transform.position, wayPointFinal.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPointFinal.position, finalSpeed * Time.deltaTime
                );

                yield return null;
            }
                
        playerAnimator.SetFloat("speed", 0);
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(-1,1,1);
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(1);

        playerAnimator.SetBool("run", true);
        playerAnimator.SetFloat("speed", 2);

        while(Vector2.Distance(transform.position, wayPointEnd.position) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPointEnd.position, EndSpeed * Time.deltaTime
                );

                yield return null;
            }

            playerAnimator.SetFloat("speed", 0);
    }

}