using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTwo : MonoBehaviour
{
    public Transform player;
    public Transform spawnPointLevel2;
    public GameObject BlackDog;
    public GameObject DarkView;
     bool playerInside = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInside && Input.GetKeyDown(KeyCode.F))
        {
            player.position = spawnPointLevel2.position;
            Destroy(BlackDog);
            DarkView.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
