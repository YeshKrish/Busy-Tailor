using BusyTailor_Human;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public static HumanManager Instance;

    private HumanPool _humanPool;
    [SerializeField]
    private int _maxHumansCanBeActiveOnScene = 6;
    [SerializeField]
    private Transform _humanSpawnPoint;
    [SerializeField]
    private float _hmaunSpawnInterval = 2f;

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
        StartCoroutine(SpawnHumans());
    }

    private IEnumerator SpawnHumans()
    {
        while (_humanPool._activeHuman.Count < _maxHumansCanBeActiveOnScene)
        {
            yield return new WaitForSeconds(_hmaunSpawnInterval);
            GameObject human = _humanPool.FetchHuman();
            human.transform.position = _humanSpawnPoint.position;
            human.GetComponent<Human>().WalkingState();
        }
    }

    //private IEnumerator Spawn() 
    //{
    //    yield return new WaitForSeconds(_hmaunSpawnInterval);
    //    GameObject human = _humanPool.FetchHuman();
    //    human.transform.position = _humanSpawnPoint.position;
    //}

    //private void Update()
    //{
    //    if(_humanPool._activeHuman.Count < _maxHumansCanBeActiveOnScene)
    //    {
    //        GameObject human = _humanPool.FetchHuman();
    //        human.transform.position = _humanSpawnPoint.position;
    //    }
    //}
}