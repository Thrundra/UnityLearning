using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypointsSceneTwo : MonoBehaviour
{
    public Transform spriteTransform;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float moveSpeed = 1f;
    public float arrivalThreshold = 0.25f;
    public bool enableCircularWaypoints = false;
    public int numberOfWaypoints = 0;
    public GameObject targetGameObject;
    public string targetTag;

    // Debug Variables.
    

    // Start is called before the first frame update
    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        waypoints = new Transform[numberOfWaypoints];
        for (int i = 0; i < numberOfWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("Waypoint" + (i + 1)).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {

            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            Vector3 moveDirection = targetPosition - spriteTransform.position;
            float distanceToWaypoint = moveDirection.magnitude;

            // Move the sprite towards the waypoint
            spriteTransform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            if (distanceToWaypoint < arrivalThreshold)
            {
                Debug.Log("I'm at waypoint " + currentWaypointIndex);
                currentWaypointIndex++;
            }

            if (enableCircularWaypoints)
            {
                if (currentWaypointIndex == numberOfWaypoints)
                {
                    currentWaypointIndex = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I HAVE ARRIVED TO COLLIDE");

        if (collision.CompareTag(targetTag))
        {
            Debug.Log("i've hit something");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I HAVE ARRIVED TO COLLIDE");

        if (collision.gameObject.tag == targetTag) 
        {
            Debug.Log("i've hit something");
            Destroy(this.gameObject);
        }
    }
}
