using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlackBG : MonoBehaviour
{
    public GameObject BlackBG;
 void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(BlackBG);
        }
    }
}
