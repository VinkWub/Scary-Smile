using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    private Light2D light2D;

    public float minTime = 0.05f;
    public float maxTime = 0.2f;

    private bool isFlickering = false;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isFlickering)
        {
            isFlickering = true;
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        while(true)
        {
            light2D.enabled = !light2D.enabled;
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}