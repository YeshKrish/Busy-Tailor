using BusyTailor_Worker;
using UnityEngine;

public class MoveTowardsWorkBenchState : IWorkerState
{
    public void EnterState(Worker worker)
    {
        Debug.Log("Worker MoveTowardsWorkBenchState State");
    }
    public void UpdateState(Worker worker)
    {
        if (worker._workPoint != null)
        {
            if (worker.MoveTowardsTarget(worker._workPoint))
            {
                Debug.Log("DistanceCovered");
                worker.WorkingState();
            }
        }
    }
    public void ExitState(Worker worker)
    {

    }
}
