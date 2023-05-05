using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip saltoclip;
    
 
    public GameObject bala;
    public float runSpeeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;

    //doble salto
    public float doubleJumpSpeed = 2.5f;
//salto en el aire
    private bool canDoubleJump;

    public SpriteRenderer spriteRenderer;

    public Animator animacion;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    //para el segundo salto
    private void Update()
    {
        if (Input.GetKey("space") )
        {
            saltar();
            
        }
        
        if (CheckGround.isGrounded==false)
        {
            animacion.SetBool("Jump",true);
            animacion.SetBool("Run", false);
        }

        if (CheckGround.isGrounded==true)
        {
            animacion.SetBool("Jump", false);
            animacion.SetBool("DoubleJump", false);
            animacion.SetBool("Falling", false);
        }
        
        
            if (rb2D.velocity.y<0)
            {
                animacion.SetBool("Falling",true);
            }

            if (rb2D.velocity.y>0)
            {
                animacion.SetBool("Falling",false);
            }
        
            if (Input.GetKeyDown("m")){
                Disparar();
            }
            
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            derecha();
            
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {
            detener();
            
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
           izquierda();
   
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {
            detener();
        }    
        
    }


    void FixedUpdate()
    {
        
        
        
  
    }

    public void Disparar () {
            if(spriteRenderer.flipX == false){
                Debug.Log("Flipx 1 : " + spriteRenderer.flipX);
              var balaPosition = transform.position + new Vector3(0.3f,0,0);
              var gb = Instantiate(bala, 
                                   balaPosition,
                                   Quaternion.identity)
                                   as GameObject;
              var controller = gb.GetComponent<balaController>();
              controller.SetRightDirection();
            }
            if(spriteRenderer.flipX == true){
                Debug.Log("Flipx 2 : " + spriteRenderer.flipX);
              var balaPosition = transform.position + new Vector3(-0.3f,0,0);
              var gb = Instantiate(bala, 
                                   balaPosition,
                                   Quaternion.identity)
                                   as GameObject;
              var controller = gb.GetComponent<balaController>();
              controller.SetLeftDirection();
            }
    }
    public void derecha () {
            rb2D.velocity = new Vector2(runSpeeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animacion.SetBool("Run", true);
    }
    public void izquierda () {
            rb2D.velocity = new Vector2(-runSpeeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animacion.SetBool("Run", true);
    }
    public void detener(){
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animacion.SetBool("Run", false);
    }

    public void saltar () {
        audioSource.PlayOneShot(saltoclip);
            
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animacion.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
    }

}
