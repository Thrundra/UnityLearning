using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTable : MonoBehaviour
{

    public Transform target;
    public float spriteSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * spriteSpeed * Time.deltaTime);
    }
}
