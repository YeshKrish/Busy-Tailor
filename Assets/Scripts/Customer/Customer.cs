using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BusyTailor_Human;


public class Customer : Human
{
    private ICustomerState _currentState;
    [Header("Customer Requirement UI")]
    private GameObject _orderingUI;
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
    public override void BecomeHuman()
    {
        GetComponent<Human>().enabled = true;
        base.BecomeHuman();
    }
    internal void ActivateOderingUI()
    {
        _orderingUI.SetActive(true);
    }
    internal void DeactivateOderingUI()
    {
        _orderingUI.SetActive(false);
    }
    internal void SetOderUI(GameObject ui)
    {
        _orderingUI = ui;
    }
}





