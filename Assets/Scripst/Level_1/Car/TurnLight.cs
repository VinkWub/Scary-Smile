using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurnLight : MonoBehaviour
{
    public GameObject gameObjectBG;
    public Light2D CarLight1;
    public Light2D CarLight2;
    public Light2D CarLight3;
    public Light2D CarLight4;
    // Start is called before the first frame update
    void Start()
    {
        CarLight1.enabled = false;
        CarLight2.enabled = false;
        CarLight3.enabled = false;
        CarLight4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CarLight1.enabled = true;
            CarLight2.enabled = true;
            CarLight3.enabled = true;
            CarLight4.enabled = true;
            Destroy(gameObjectBG);
        }
    }
}
