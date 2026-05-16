using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : MonoBehaviour
{
    public GameObject keyImage;
    public GameObject wayPoint;
    private bool isShowing = false;
    // [SerializeField] private float delayTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            keyImage.SetActive(true);
            Time.timeScale = 0f;
            isShowing = true;
        }
    }

    void Update()
    {
        if(isShowing && Input.GetKeyDown(KeyCode.Q))
        {
            CloseImage();
            Destroy(wayPoint);
        }
    }

    public void CloseImage()
    {
        // yield return new WaitForSeconds(delayTime);
        keyImage.SetActive(false);
        Time.timeScale = 1f;
        isShowing = false;
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         keyImage.SetActive(false);
    //     }
    // }
}
