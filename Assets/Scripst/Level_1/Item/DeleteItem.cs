using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
 public int slotIndex;

 public void DeleteItems()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.RemoveItem(GameManager.instance.item[slotIndex]);
        }
    }
}
