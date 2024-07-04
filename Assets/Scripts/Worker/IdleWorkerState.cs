using BusyTailor_Worker;
using UnityEngine;

public class IdleWorkerState : IWorkerState
{

    public void EnterState(Worker worker)
    {
        Debug.Log("Worker Idle State");
    }
    public void UpdateState(Worker worker)
    {
        bool hasCustomer = worker.CheckForCustomersInQueue();
        if(hasCustomer)
        {
            worker.MoveTowardsCustomerState();
        }
    }
    public void ExitState(Worker worker)
    {

    }
}
