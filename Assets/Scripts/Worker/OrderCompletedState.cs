using BusyTailor_Worker;
using UnityEngine;

public class OrderCompletedState : IWorkerState
{
    public void EnterState(Worker worker)
    {
        worker._reward.AddReward(10);
        worker._cloth.SetActive(false);
        worker._presentCustomer.CustomerReceivedOrder();
        worker._presentCustomer = null;
        worker._presentCustomerOrderPos = null;
        worker.IdleWorkerState();
    }

    public void UpdateState(Worker worker)
    {
    }

    public void ExitState(Worker worker)
    {

    }
}
