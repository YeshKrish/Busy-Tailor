using UnityEngine;

namespace BusyTailor_Human
{
    public class Human : MonoBehaviour
    {
        private IHumanState _currentState;
        private QueueManager _queueManager;

        [SerializeField]
        private float _turningCustomerProbability = 0.5f;

        [Header("Human Properties")]
        public int CurrentWaypointIndex = 0;
        public float Speed = 2f;
        public float WaypointReachedThreshold = 0.1f;

        [Header("Customer Requirement UI")]
        [SerializeField]
        internal GameObject _orderingUI;

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
                customer.SetOderUI(_orderingUI);
                this.enabled = false;
            }
        }

        public virtual void BecomeHuman()
        {
            Customer customer = gameObject.GetComponent<Customer>();
            if(customer != null)
            {
                Destroy(customer);
                WalkingState();
            }
            else
            {
                Debug.Log("Customer Missing");
            }
        }
    }

}
