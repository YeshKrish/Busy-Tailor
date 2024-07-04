using UnityEngine;

public class WalkingState : IHumanState
{
    private int currentWaypointIndex = 0;
    public float speed = 2f;
    public float waypointReachedThreshold = 0.1f;

    public void EnterState(Human human) 
    {
        Debug.Log("Walk");
    }
    public void UpdateState(Human human) 
    {
        Debug.Log("Waling Update");
        if (currentWaypointIndex < HumanManager.Instance.WayPoints.Length)
        {
            Transform targetWaypoint = HumanManager.Instance.WayPoints[currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - human.transform.position).normalized;
            float distance = Vector3.Distance(human.transform.position, targetWaypoint.position);

            // Move the player
            human.transform.position = Vector3.MoveTowards(human.transform.position, targetWaypoint.position, speed * Time.deltaTime);

            // Check if the player has reached the waypoint
            if (distance < waypointReachedThreshold)
            {
                if (currentWaypointIndex == 1)
                {
                    if (human.TryBecomeCustomer())
                    {
                        currentWaypointIndex++;
                        return;   
                    }
                }
                else if (currentWaypointIndex == 2)
                {
                    HumanManager.Instance._humanPool.MoveToInactive(human.gameObject);
                    return;
                }
                currentWaypointIndex++;
            }
        }
    }
    public void ExitState(Human human) { /* Stop walking */ }
}
