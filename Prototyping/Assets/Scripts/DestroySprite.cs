using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySprite : MonoBehaviour
{
    public string targetTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I HAVE ARRIVED TO COLLIDE");

        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("i've hit something");
            Destroy(gameObject);
        }
    }
/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I HAVE ARRIVED TO COLLIDE");

        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("i've hit something");
            Destroy(gameObject);
        }
    }*/
}
