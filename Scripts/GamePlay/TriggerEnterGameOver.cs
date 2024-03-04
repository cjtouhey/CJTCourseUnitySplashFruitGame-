using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterGameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverScreen.SetActive(true);
        
    }
}
