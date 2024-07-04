using UnityEngine;

public class CustomerMovingToShopState : ICustomerState
{
    public float speed = 2f;
    private Transform _assignedLocation;
    public void EnterState(Customer customer)
    {
        _assignedLocation = QueueManager.Instance.FetchAssignedPoint(customer);
        Debug.Log("Moving Towards Shop" + _assignedLocation.position);

    }
    public void UpdateState(Customer customer)
    {
        if(_assignedLocation != null && customer.transform.position != _assignedLocation.transform.position)
        {
            Debug.Log("Update Move");
            customer.transform.position = Vector3.MoveTowards(customer.transform.position, _assignedLocation.position, speed * Time.deltaTime);
        }
    }
    public void ExitState(Customer customer)
    {

    }
}
