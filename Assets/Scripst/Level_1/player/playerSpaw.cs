using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpaw : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        StartCoroutine(ShowPlayer());
    }

    IEnumerator ShowPlayer()
    {
        yield return new WaitForSeconds(delayTime);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
