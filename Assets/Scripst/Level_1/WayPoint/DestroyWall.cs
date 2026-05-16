using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{

    public GameObject wayPoint;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isShowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isShowing = false;
        }
    }

    // Update is called once per frame
  

        void Update()
    {
        if(isShowing && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(wayPoint);
            isShowing = false;
        }
    }
    
}
