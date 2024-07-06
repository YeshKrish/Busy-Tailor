using UnityEngine;
using BusyTailor_Human;
public class WalkingState : IHumanState
{
    public void EnterState(Human human) 
    {
        Debug.Log("Walk");
    }
    public void UpdateState(Human human) 
    {
        Debug.Log("Waling Update");
        if (human.currentWaypointIndex < HumanManager.Instance.WayPoints.Length)
        {
            Transform targetWaypoint = HumanManager.Instance.WayPoints[human.currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - human.transform.position).normalized;
            float distance = Vector3.Distance(human.transform.position, targetWaypoint.position);

            // Move the player
            human.transform.position = Vector3.MoveTowards(human.transform.position, targetWaypoint.position, human.speed * Time.deltaTime);

            // Check if the player has reached the waypoint
            if (distance < human.waypointReachedThreshold)
            {
                if (human.currentWaypointIndex == 1)
                {
                    if (human.TryBecomeCustomer())
                    {
                        human.currentWaypointIndex++;
                        return;   
                    }
                }
                else if (human.currentWaypointIndex == 2)
                {
                    HumanManager.Instance._humanPool.MoveToInactive(human.gameObject);
                    human.currentWaypointIndex = 0;
                    return;
                }
                human.currentWaypointIndex++;
            }
        }
    }
    public void ExitState(Human human) { /* Stop walking */ }
}
