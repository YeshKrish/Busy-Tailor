using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public static QueueManager Instance;

    private int _maxQueueSize = 3;
    private Queue<Customer> _customerQueue;

    [SerializeField]
    private Transform[] _waitingPoints;

    private Dictionary<Customer, Transform> _allocatedPositionDict = new();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        _customerQueue = new Queue<Customer>();
    }

    public bool HasSpace()
    {
        return _customerQueue.Count < _maxQueueSize;
    }

    public bool AddToQueue(Customer customer)
    {
        if (HasSpace())
        {
            _customerQueue.Enqueue(customer);
            
            return true;
        }
        return false;
    }
    public void RemoveFromQueue(Customer customer)
    {
        if (_customerQueue.Contains(customer))
        {
            _customerQueue = new Queue<Customer>(_customerQueue.Where(c => c != customer));
            RemoveAssignedPoint(customer);
        }
    }

    //private void AssignPoint(Customer customer)
    //{
    //    if(_allocatedPositionDict.Count > 0)
    //    {
    //        for (int i = 0; i < _waitingPoints.Length; i++)
    //        {
    //            if (!_allocatedPositionDict.ContainsValue(_waitingPoints[i]))
    //            {
    //                _allocatedPositionDict[customer] = _waitingPoints[i];
    //                break;
    //            } 
    //        }

    //    }
    //    else
    //    {
    //        _allocatedPositionDict[customer] = _waitingPoints[0];
    //    }
    //}

    private void RemoveAssignedPoint(Customer customer)
    {
        if (_allocatedPositionDict.ContainsKey(customer))
        {
            _allocatedPositionDict.Remove(customer);
        }
    }

    internal Transform FetchAssignedPoint(Customer customer)
    {
        if (_allocatedPositionDict.Count > 0)
        {
            for (int i = 0; i < _waitingPoints.Length; i++)
            {
                if (!_allocatedPositionDict.ContainsValue(_waitingPoints[i]))
                {
                    _allocatedPositionDict[customer] = _waitingPoints[i];
                    return _waitingPoints[i];
                }
            }

        }
        else
        {
            _allocatedPositionDict[customer] = _waitingPoints[0];
            return _waitingPoints[0];
        }
        return null;
    }

}
