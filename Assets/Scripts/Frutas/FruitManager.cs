using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;

    public static bool tv;

    private void Update()
    {
        
        AllFruitsCollected();
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("No quedan frutas, VICTORIA"); 
            
            levelCleared.gameObject.SetActive(true);
            //pasar de una escena a otra
            //Invoke("ChangeScene",4);
            tv = true;
        }
    }

    //void ChangeScene()
   // {
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

}
