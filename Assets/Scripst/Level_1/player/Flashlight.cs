using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    public Light2D flashlight;
    public Interact interactUI;
    private bool flashlightStart = false;
    [SerializeField] private float flashlightCtrl;
    void Start()
    {
        flashlightStart = false;
    }
    void Update()
    {
         if(flashlightStart == false)
        {
        StartCoroutine(flashStart());
        }
        else if(flashlightStart == true)
        {
        if(Input.GetKeyDown(KeyCode.E))
        {
            flashlight.enabled = !flashlight.enabled;
            interactUI.SetActiveButton();
        }
        else if(!flashlight.enabled)
        {
            interactUI.SetInactiveButton();
        }
        }
    }
    IEnumerator flashStart()
    {
        yield return new WaitForSeconds(flashlightCtrl);
        flashlightStart = true;
    }
}
