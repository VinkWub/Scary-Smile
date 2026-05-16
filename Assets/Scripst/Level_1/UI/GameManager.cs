using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   
    public bool isPaused;

    public List<Item> item = new List<Item>();
    public List<int> itemNumbers = new List<int>(); 

    public GameObject[] slots;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DisplayItem();
    }

    private void DisplayItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < item.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = item[i].itemSprites; 
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 1);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString(); 
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
                slots[i].transform.GetChild(3).gameObject.SetActive(true);
                slots[i].transform.GetChild(3).GetComponent<UseItem>().slotIndex = i;

                GameObject deletItem = slots[i].transform.GetChild(2).gameObject;
                deletItem.SetActive(true);

                deletItem.GetComponent<DeleteItem>().slotIndex = i;
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = null;
                slots[i].transform.GetChild(2).gameObject.SetActive(false); 
                slots[i].transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        if (!item.Contains(_item)) 
        {
            item.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("You have already had this one!!!");
            for (int i = 0; i < item.Count; i++) 
            {
                if (_item == item[i])
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItem();
    }

    public void RemoveItem(Item _item)
    {
        if (item.Contains(_item))
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (_item == item[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] <= 0)
                    {
                        item.RemoveAt(i);                 
                        itemNumbers.RemoveAt(i); 
                    }
                    break;
                }
            }
        }
        else
        {
            Debug.Log("There in No " + _item + " in my Bags");
        }
        DisplayItem();
    }
}