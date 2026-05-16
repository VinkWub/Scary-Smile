using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDrink : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject keyText;
    public bool isShowing = false;

    void Update()
    {
        if(isShowing == true && Input.GetKeyDown(KeyCode.Q))
        {
            keyText.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isShowing = true;
        }
    }

    public void RemoveText()
    {
        keyText.SetActive(false);
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         keyText.SetActive(false);
    //     }
    // }
}
