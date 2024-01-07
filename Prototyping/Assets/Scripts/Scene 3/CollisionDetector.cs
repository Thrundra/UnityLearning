using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I've Collided");
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
