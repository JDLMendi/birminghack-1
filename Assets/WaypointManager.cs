using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public bool isMoving;
    public bool isPaused; // New flag for pausing
    public int waypointIndex;
    public float moveSpeed = 2.0f;

    void Start()
    {
  
    }

    public void StartMoving()
    {
        isMoving = true;
        isPaused = false; // Ensure not paused when starting
        waypointIndex = 0;
    }

    public void PauseMoving()
    {
        isPaused = true;
    }

    public void ResumeMoving()
    {
        isPaused = false;
    }

    void Update()
    {
        if (!isMoving || isPaused) // Check if paused
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, Time.deltaTime * moveSpeed);
        var distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distance < 0.05f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                isMoving = false;
            }
        }
    }
}
