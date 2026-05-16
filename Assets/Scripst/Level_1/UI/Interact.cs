using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    private Image img;
    [SerializeField] public float inactiveAlpha;
    [SerializeField] public float activeAlpha;
    // Start is called before the first frame update

    void Awake()
    {
        img  =GetComponent<Image>();
        SetInactiveButton();
    }

    public void SetActiveButton()
    {
        if(img == null) return;

        Color c = img.color;
        c.a = activeAlpha;
        img.color = c;
    }

    public void SetInactiveButton()
    {
        if(img == null) return;

        Color c = img.color;
        c.a = inactiveAlpha;
        img.color = c;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
