using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public int slotIndex;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItems()
    {
        Item item = GameManager.instance.item[slotIndex];

        if(item == null) return;

        if(item.itemName == "Bottle")
        {
            FindObjectOfType<playerSystem>().AddStamina(30f);
            GameManager.instance.RemoveItem(item);
        }

        if(item.itemName == "Plaster")
        {
            playerSystem player = FindObjectOfType<playerSystem>();
            if(player != null)
            {
                player.Heal(1);
                GameManager.instance.RemoveItem(item);
            }
        }
    }
}
