using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageObjecy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaget");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
        if (collision.transform.CompareTag("bala"))
        {
            Destroy(gameObject);
        }
    }
}


