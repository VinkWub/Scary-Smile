using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    bool playerOnWayPoint = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
    if(other.tag == "Player" )
        {
            playerOnWayPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            playerOnWayPoint = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnWayPoint == true && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(2);
        }
    }
}
