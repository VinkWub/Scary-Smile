using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSystem : MonoBehaviour
{
    public GameObject[] heardArray;
    public Slider StaminaBar;

    private int allHeart;

    [SerializeField] public float Stamina;
    [SerializeField] public float maxStamina;
    [SerializeField] public float reduceStamina;
    [SerializeField] public float regenStamina;
    [SerializeField] public float HP;
    [SerializeField] private float wait;

    private bool isWaiting = false;

    void Start()
    {
        allHeart = heardArray.Length;
        Stamina = maxStamina;
        StaminaBar.maxValue = maxStamina;
    }

    void Update()
    {
        if(Stamina > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            Stamina -= reduceStamina * Time.deltaTime;

            StopAllCoroutines();
            isWaiting = false;
        }
        else
        {
            if(!isWaiting)
            {
                StartCoroutine(waitTime());
            }
        }

        Stamina = Mathf.Clamp(Stamina, 0, maxStamina);
        StaminaBar.value = Stamina;
    }

    IEnumerator waitTime()
    {
        isWaiting = true;

        yield return new WaitForSeconds(wait);

        while(!Input.GetKey(KeyCode.LeftShift))
        {
            Stamina += regenStamina * Time.deltaTime;
            yield return null;
        }

        isWaiting = false;
    }

    public void Damage()
    {
        Debug.Log("Player Hit");

        if(allHeart > 0)
        {
            allHeart--;
            heardArray[allHeart].SetActive(false);
            HP--;
        }
    }

    public void AddStamina(float amount)
    {
        Stamina += amount;
        Stamina = Mathf.Clamp(Stamina, 0, maxStamina);
    }

    public void Heal(int amount)
    {
        if(allHeart >= heardArray.Length) return;

        for(int i = 0; i < amount; i++)
        {
            if(allHeart < heardArray.Length)
            {
                heardArray[allHeart].SetActive(true);
                allHeart++;
                HP++;
            }
        }
    }
}