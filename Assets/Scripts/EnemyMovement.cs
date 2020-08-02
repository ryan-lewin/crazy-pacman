using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float movementSpeed = 7f;

    void Start() 
    {
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    private void Update() {
        MoveWaypoint();
    }

    // void FixedUpdate() 
    // {
    //     // if(transform.position != waypoints[currentWaypoint].position)
    //     // {
    //     //     Vector2 position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, movementSpeed);
    //     //     GetComponent<Rigidbody2D>().MovePosition(position);
    //     // } else 
    //     // {
    //     //     currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    //     // }
    // }

    void MoveWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, movementSpeed * Time.deltaTime);

        if(transform.position == waypoints[currentWaypoint].transform.position)
        {
            currentWaypoint += 1;
        }

        if(currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}
