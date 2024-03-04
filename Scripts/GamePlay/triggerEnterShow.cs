using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnterShow : MonoBehaviour
{
   [SerializeField] GameObject warningLine; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            warningLine.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            warningLine.SetActive(false);
        }
    }
}

