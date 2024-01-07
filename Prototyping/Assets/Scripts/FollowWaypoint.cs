using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public Transform spriteTransform;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float moveSpeed = 1f;
    public float arrivalThreshold = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        waypoints = new Transform[5];
        for(int i = 0; i< 5;  i++)
        {
            waypoints[i] = GameObject.Find("Waypoint" + (i+1)).transform;
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
                currentWaypointIndex++;
            }

            if(currentWaypointIndex == 5)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
