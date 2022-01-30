using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerJumpscript : MonoBehaviour
{
    public static playerJumpscript instance;
    private Rigidbody2D mybody;
    private Animator anim;
    [SerializeField]
    private float forceX , forceY;
    private float thresholdX = 7f;
    private float thresholdY = 14f;

    private bool setpower, didJump;

    private Slider powerbar;
    private float powerbarThreshold = 10f;
    private float powerbarValue = 0f;

    private void Awake()
    {
        instance = this;
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        powerbar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerbar.minValue = 0f;
        powerbar.maxValue = 10f;
        powerbar.value = powerbarValue;
    }

    void setPower()
    {
        if(setpower)
        {
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;

            if(forceX > 6.5f)
                forceX = 6.5f;
            
            if(forceY > 13.5f)
                forceY = 13.5f;

            powerbarValue += powerbarThreshold * Time.deltaTime;
            powerbar.value = powerbarValue;
        }
    }

    
    void Update()
    {
        setPower();
    }


    public void setPower(bool setpower)
    {
        this.setpower = setpower;

        if(!setpower)
        {
            jump();
        }

    }

    public void jump()
    {
        mybody.velocity = new Vector2(forceX , forceY);
        forceX = forceY = 0f;
        didJump = true;

        anim.SetBool("Jump" , didJump);
        
        powerbarValue = 0f;
        powerbar.value = powerbarValue;
    }


    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(didJump)
        {
            didJump = false;
            anim.SetBool("Jump" , didJump);

            if(other.tag == "Platform") 
            {
                GameManager.gameInstance.createNewPlatformandLerp(other.transform.position.x);

                Scoremanager.scoreinstance.addScore();
            }

            if(other.tag == "Dead")
            {
               GameOvermanager.Goinstance.showGameOverPanel();
               

                //Destroy(gameObject);
            }   

        }    
    }
}
