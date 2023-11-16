using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
}
