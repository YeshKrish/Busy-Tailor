using BusyTailor_Worker;

public interface IWorkerState
{
    void EnterState(Worker worker);
    void UpdateState(Worker worker);
    void ExitState(Worker worker);
}
