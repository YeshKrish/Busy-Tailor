using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : MonoBehaviour
{
    private IHumanState _currentState;
    private QueueManager _queueManager;

    [SerializeField]
    private float _turningCustomerProbability = 0.5f;


    public void WalkingState()
    {
        TransitionState(new WalkingState());
    }

    public void TransitionState(IHumanState state)
    {
        _currentState?.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    void Update()
    {

        if(_queueManager == null)
        {
            _queueManager = QueueManager.Instance;
        }
        _currentState?.UpdateState(this);
    }

    public bool TryBecomeCustomer()
    {
        if (_queueManager.HasSpace())
        {
            if(Random.value < _turningCustomerProbability)
            {
                BecomeCustomer();
                return true;
            }
        }
        return false;
    }

    private void BecomeCustomer()
    {
        var customer = gameObject.AddComponent<Customer>();
        if (_queueManager.AddToQueue(customer))
        {
            //customer.MemberwiseClone();
            customer.MovingTowardsShop();
            this.enabled = false;
        }
    }
}
