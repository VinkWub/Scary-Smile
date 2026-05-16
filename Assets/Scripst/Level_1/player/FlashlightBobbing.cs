using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBobbing : MonoBehaviour
{
    public Transform flashlight;
    public float bobSpeed = 8f;
    public float bobAmount = 0.05f;
    Vector3 startPos;
    void Start()
    {
        startPos = flashlight.localPosition;
    }

    void Update()
    {
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        flashlight.localPosition = startPos + new Vector3(0, bob, 0);
    }
}
