public interface ICustomerState
{
    public void EnterState(Customer customer);
    public void UpdateState(Customer customer);
    public void ExitState(Customer customer);
}