using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{

    private Scene _scene;

    private void Awake(){
        _scene=SceneManager.GetActiveScene(); //caching
    }

   private void OnTriggerEnter2D(Collider2D other){

    if (other.gameObject.CompareTag("Player")){
        SceneManager.LoadScene("StartScene");
    }
   }

   public void StartLevel(){
        SceneManager.LoadScene("StartScene");
   }
}
