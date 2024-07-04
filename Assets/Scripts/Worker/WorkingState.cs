using BusyTailor_Worker;
using UnityEngine;

public class WorkingState : IWorkerState
{
    private float _workTime = 5f;
    public void EnterState(Worker worker)
    {
        Debug.Log("Worker WorkingState State");
        worker.StartRadialTimer(_workTime);
    }    
    public void UpdateState(Worker worker)
    {

    }    
    public void ExitState(Worker worker)
    {

    }
}
