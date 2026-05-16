using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public Item itemData;
    public GameObject pickupEffect;
    bool playerInRange = false;
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D other) 
{
    if(other.tag == "Player" )
        {
            playerInRange = true;
        }
}
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if(playerInRange == true && Input.GetKey(KeyCode.F))
        {
            if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }

            Destroy(gameObject);
            GameManager.instance.AddItem(itemData);
        } 
    }
}
