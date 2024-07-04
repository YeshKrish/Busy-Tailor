using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BusyTailor_Human;


public class Customer : Human
{
    private ICustomerState _currentState;

    private void TransitionState(ICustomerState customerState)
    {
        _currentState?.ExitState(this);
        _currentState = customerState;
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState?.UpdateState(this);
    }

    public void MovingTowardsShop()
    {
        TransitionState(new CustomerMovingToShopState());
    }
    public void CustomerOrdering()
    {
        TransitionState(new CustomerOrderingState());
    }
    public void CustomerWaiting()
    {
        TransitionState(new CustomerWaitingState());
    }
    public void CustomerReceivedOrder()
    {
        TransitionState(new CustomerReceivedOrderState());
    }

}





