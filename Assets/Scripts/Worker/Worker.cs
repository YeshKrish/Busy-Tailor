using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BusyTailor_Worker
{
    public class Worker : MonoBehaviour
    {
        private IWorkerState _currentState;

        [SerializeField]
        private Transform[] _workerPoints;
        [SerializeField]
        internal Transform _workPoint;
        [SerializeField]
        private Image _timerImage;
        [SerializeField]
        internal GameObject _cloth;

        internal Transform _presentCustomerOrderPos;
        internal Customer _presentCustomer;

        private float _currentTime;

        private float _speed = 2f;
        private float _distanceTreshold = 0.1f;

        [Header("Reward")]
        [SerializeField]
        internal RewardSo _reward;

        private void Start()
        {
            IdleWorkerState();
        }

        public void TransitionState(IWorkerState state)
        {
            _currentState?.ExitState(this);
            _currentState = state;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            Debug.Log("Worker Curr State" + _currentState);
            _currentState?.UpdateState(this);
        }

        public void MoveTowardsCustomerState()
        {
            TransitionState(new MoveTowardsCustomerState());
        }
        public void MoveTowardsWorkBenchState()
        {
            TransitionState(new MoveTowardsWorkBenchState());
        }
        public void TakingOrderState()
        {
            TransitionState(new TakingOrderState());
        }
        public void WorkingState()
        {
            TransitionState(new WorkingState());
        }  
        public void OrderCompletedState()
        {
            TransitionState(new OrderCompletedState());
        }
        public void IdleWorkerState()
        {
            TransitionState(new IdleWorkerState());
        }
        internal bool CheckForCustomersInQueue()
        {
            Dictionary<Customer, int> fetchedQueuePos = QueueManager.Instance.FetchCustomerFromQueue();
            if (fetchedQueuePos.Count > 0)
            {
                SetPresentCustomer(_workerPoints[fetchedQueuePos.Values.FirstOrDefault()], fetchedQueuePos.Keys.FirstOrDefault());
                return true;
            }
            return false;
        }
        internal void SetPresentCustomer(Transform customerTransform, Customer customer)
        {
            _presentCustomerOrderPos = customerTransform;
            _presentCustomer = customer;
        }
        internal void StartRadialTimer(float targetTime)
        {
            _timerImage.transform.parent.gameObject.SetActive(true);
            StartCoroutine(StartTimer(targetTime));
        }
        private IEnumerator StartTimer(float targetTime)
        {
            _currentTime = 0f;
            while (_currentTime < targetTime)
            {
                _timerImage.fillAmount = _currentTime / targetTime;
                _currentTime += Time.deltaTime;
                yield return null;
            }
            _timerImage.fillAmount = 1f;
            OnTimerComplete();
        }
        private void OnTimerComplete()
        {
            _timerImage.transform.parent.gameObject.SetActive(false);
            if(_currentState is TakingOrderState)
            {
                MoveTowardsWorkBenchState();
            }
            else if(_currentState is WorkingState)
            {
                _cloth.SetActive(true);
                MoveTowardsCustomerState();
            }
        }

        internal bool MoveTowardsTarget(Transform target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) < _distanceTreshold)
            {
                return true;
            }
            return false;
        }
    }
}


