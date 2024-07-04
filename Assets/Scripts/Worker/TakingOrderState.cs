using BusyTailor_Worker;
using System;
using UnityEngine;

public class TakingOrderState : IWorkerState
{
    private float _workTime = 3f;
    public void EnterState(Worker worker)
    {
        worker.StartRadialTimer(_workTime);
    }
    public void UpdateState(Worker worker)
    {
        Debug.Log("Worker TakingOrderState State");
    }
    public void ExitState(Worker worker)
    {

    }


}
