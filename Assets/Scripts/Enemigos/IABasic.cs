using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasic : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float waitTime;
    public Transform[] moveSpots;
    public float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;
        
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
        
    void Start()
    {
        waitTime = startWaitTime;
    }


    void Update()
    {
        StartCoroutine(CheckenemyMoving());
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,speed*Time.deltaTime);

        if (Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f)
        {
            if (waitTime<=0)
            {
                if (moveSpots[i]!=moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckenemyMoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x>actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x==actualPos.x)
        {
            animator.SetBool("Idle", true);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("bala"))
        {
            
            Destroy(gameObject);
            puntaje.SumarPuntos(cantidadPuntos);
        }
    }
}
