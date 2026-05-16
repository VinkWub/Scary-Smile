using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class turnOfFlashlight : MonoBehaviour
{
    public Light2D flashlight;
    private bool turn = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && turn)
        {
            flashlight.enabled = !flashlight.enabled;
            turn = false;
        }
    }
}
