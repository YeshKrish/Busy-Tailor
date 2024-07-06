using UnityEngine;
public class CustomerReceivedOrderState : ICustomerState
{
    public void EnterState(Customer customer)
    {
        Debug.Log("Customer CustomerReceivedOrderState State");
        customer.DeactivateOderingUI();
        QueueManager.Instance.RemoveFromQueue(customer);
        customer.BecomeHuman();
    }
    public void UpdateState(Customer customer)
    {

    }
    public void ExitState(Customer customer)
    {

    }
}
