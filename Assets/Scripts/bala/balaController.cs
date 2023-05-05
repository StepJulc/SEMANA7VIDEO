using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaController : MonoBehaviour
{   

    private float velocity = 1;
    float realVelocity;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool band = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
        sr.flipX = band;
    
        Destroy(this.gameObject,5);
    }
    public void SetRightDirection(){
        realVelocity = velocity;
        band = false;
        
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
        band = true;
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "enemigo"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "suelo"){
            Destroy(this.gameObject);
        }
       
    }
}
