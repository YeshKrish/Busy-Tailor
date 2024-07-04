
using UnityEngine;

public class WayPointHandler : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;
    public float waypointReachedThreshold = 0.1f;

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        // Move the player
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the player has reached the waypoint
        if (distance < waypointReachedThreshold)
        {
            OnWaypointReached();
        }
    }

    void OnWaypointReached()
    {
        if (currentWaypointIndex == 1)
        {
            CallFunctionAtSecondWaypoint();
        }
        else if (currentWaypointIndex == 2)
        {
            CallFunctionAtThirdWaypoint();
        }

        // Move to the next waypoint
        currentWaypointIndex++;
    }

    void CallFunctionAtSecondWaypoint()
    {
        Debug.Log("Reached second waypoint, calling function.");
        // Your function logic here
    }

    void CallFunctionAtThirdWaypoint()
    {
        Debug.Log("Reached third waypoint, calling function.");
        // Your function logic here
    }
}
