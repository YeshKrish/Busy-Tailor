public class CustomerOrderingState : ICustomerState
{
    public void EnterState(Customer customer)
    {
        customer.ActivateOderingUI();
    } 
    public void UpdateState(Customer customer)
    {

    } public void ExitState(Customer customer)
    {

    }
}
