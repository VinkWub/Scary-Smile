using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{

    public Interact interactUI;
    void Start()
    {
        FindUI();
    }

    void FindUI()
    {
        if(interactUI == null)
        {
            interactUI = FindObjectOfType<Interact>();
        }
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindUI();

            if(interactUI != null)
            interactUI.SetActiveButton();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindUI();

            if(interactUI != null)
            interactUI.SetInactiveButton();
        }
    }
}
