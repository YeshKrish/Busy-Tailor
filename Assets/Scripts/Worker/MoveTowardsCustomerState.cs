using BusyTailor_Worker;
using UnityEngine;

public class MoveTowardsCustomerState : IWorkerState
{
    private bool _hasCloth;

    public void EnterState(Worker worker)
    {
        Debug.Log("Worker MoveTowardsCustomerState State");
    }
    public void UpdateState(Worker worker)
    {
        if(worker._presentCustomerOrderPos != null && !_hasCloth)
        {
            if(worker.MoveTowardsTarget(worker._presentCustomerOrderPos))
            {
                if (worker._cloth.activeSelf)
                {
                    _hasCloth = true;
                    worker.OrderCompletedState();
                }
                else
                {
                    _hasCloth = false;
                    Debug.Log("DistanceCovered");
                    worker.TakingOrderState();
                    worker._presentCustomer.CustomerOrdering();
                }
            }
        }
    }
    public void ExitState(Worker worker)
    {

    }
}
