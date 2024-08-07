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
        if (human.CurrentWaypointIndex < HumanManager.Instance.WayPoints.Length)
        {
            Transform targetWaypoint = HumanManager.Instance.WayPoints[human.CurrentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - human.transform.position).normalized;
            float distance = Vector3.Distance(human.transform.position, targetWaypoint.position);

            // Move the player
            human.transform.position = Vector3.MoveTowards(human.transform.position, targetWaypoint.position, human.Speed * Time.deltaTime);

            // Check if the player has reached the waypoint
            if (distance < human.WaypointReachedThreshold)
            {
                if (human.CurrentWaypointIndex == 1)
                {
                    if (human.TryBecomeCustomer())
                    {
                        human.CurrentWaypointIndex++;
                        return;   
                    }
                }
                else if (human.CurrentWaypointIndex == 2)
                {
                    HumanManager.Instance._humanPool.MoveToInactive(human.gameObject);
                    human.CurrentWaypointIndex = 0;
                    return;
                }
                human.CurrentWaypointIndex++;
            }
        }
    }
    public void ExitState(Human human) { /* Stop walking */ }
}
