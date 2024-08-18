using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    Rigidbody2D rigid2D;

    private Vector2 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
 
        targetPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        { 
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPoint.z = transform.position.z;

        }

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
}
