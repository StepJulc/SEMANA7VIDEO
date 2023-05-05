using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    //public float puntajeMinimo = 3;
   
    
   // [SerializeField] private float cantidadPuntos;
    //[SerializeField] private Puntaje puntaje;

    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("ChangeScene",1);
        }

    }

    public void ChangeScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
