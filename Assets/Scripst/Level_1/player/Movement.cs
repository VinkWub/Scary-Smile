using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Animator playerAnimator;
    private bool playerStart = false;
    [SerializeField] private float topSpeed;
    [SerializeField] private float speedStart;
    [SerializeField] private float delayCtrl;
    public bool playerRun = false;
    public bool stopPlayer = false;
    public GameObject setUI;
    public playerSystem System;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStart = false;

        StartCoroutine(gameStart());
    }
    void Update()
    {
    if(!playerStart) return;
    
    float horizontal = Input.GetAxisRaw("Horizontal");
    bool isMoving = Mathf.Abs(horizontal) > 0.01f;

    if(System.Stamina > 0)
    {
        playerRun = isMoving && Input.GetKey(KeyCode.LeftShift);
    }
    else
    {
        playerRun = false;
    }

    float currentSpeed = playerRun ? topSpeed : speedStart;

    if(stopPlayer)
        {
            playerRigid.velocity = Vector2.zero;
            return;
        }

    playerRigid.velocity = new Vector2(horizontal * currentSpeed, playerRigid.velocity.y);

    playerAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    playerAnimator.SetBool("run", playerRun);

    if(horizontal > 0.01f)
    {
        transform.localScale = new Vector3(1,1,1);
    }
    else if(horizontal < -0.01f)
    {
        transform.localScale = new Vector3(-1,1,1);
    }

    if(System.HP <= 0)
        {
            Restart.instance.GameOver();
            gameObject.SetActive(false);
            setUI.SetActive(false);
        }
    }

        IEnumerator gameStart()
    {
        yield return new WaitForSeconds(delayCtrl);
        playerStart = true;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Final_Point"))
        {
            stopPlayer = true;
            System.Stamina = -1;
            playerAnimator.SetBool("run", false);
        }
    }
}
