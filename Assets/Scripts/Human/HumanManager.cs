using BusyTailor_Human;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public static HumanManager Instance;

    internal HumanPool _humanPool;
    [SerializeField]
    private int _maxHumansCanBeActiveOnScene = 6;
    [SerializeField]
    private Transform _humanSpawnPoint;
    [SerializeField]
    private float _hmaunSpawnInterval = 3.5f;

    public Transform[] WayPoints;

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

    private void Start()
    {
        _humanPool = GetComponent<HumanPool>();
        InvokeRepeating("SpawnHumans", 0f, _hmaunSpawnInterval);
    }


    private void SpawnHumans()
    {
        GameObject human = _humanPool.FetchHuman();
        human.transform.position = _humanSpawnPoint.position;
        human.GetComponent<Human>().WalkingState();
    }
    
}
