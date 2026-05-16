using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject allUI;
    private bool UIStart = false;
    private bool ui = false;
    [SerializeField] private float UICtrl;
    // Start is called before the first frame update
    void Start()
    {
        UIStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UIStart == false)
        {
        StartCoroutine(AllUIStart());
        ui = true;
        }
        else if(UIStart == true && ui == true)
        {
            allUI.SetActive(!allUI.activeSelf);
            ui = false;
        }
    }
    IEnumerator AllUIStart()
    {
        yield return new WaitForSeconds(UICtrl);
        UIStart = true;
        
    }
}
