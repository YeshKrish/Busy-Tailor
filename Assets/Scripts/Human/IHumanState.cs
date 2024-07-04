public interface IHumanState
{
    void EnterState(Human human);
    void UpdateState(Human human);
    void ExitState(Human human);
}