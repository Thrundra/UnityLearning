using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{

    public float cameraSpeed = 10;
    private Vector2 cameraMotion;


    // Update is called once per frame
    void Update()
    {
        cameraMotion =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(cameraMotion * cameraSpeed * Time.deltaTime);
    }
}
