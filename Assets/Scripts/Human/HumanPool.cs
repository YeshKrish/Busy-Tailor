using BusyTailor_Human;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanPool : MonoBehaviour
{
    [Header("Pool Size")]
    [SerializeField]
    private int _maxHumanPool;

    [Header("Human Properties")]
    [SerializeField]
    private List<GameObject> _human;
    [SerializeField]
    private Transform _humanSpawnParent;
    [Space(10)]
    private List<GameObject> _humansList = new();

    internal List<GameObject> _activeHuman = new();

    private void Start()
    {
        for (int i = 0; i < _maxHumanPool; i++)
        {
            int randHumanVal = (int)Random.Range(0,10);
            GameObject human = Instantiate(_human[randHumanVal], _humanSpawnParent);
            human.SetActive(false);
            _humansList.Add(human);
        }
    }

    internal GameObject FetchHuman()
    {
        if(_humansList.Count > 0)
        {
            for (int i = 0; i < _humansList.Count; i++)
            {
                int randHuman = Random.Range(0, _humansList.Count - 1);
                GameObject human = _humansList[randHuman];
                if (!human.activeSelf)
                {
                    human.SetActive(true);
                    _activeHuman.Add(human);
                    return human;
                }
            }
        }
        return null;
    }

    internal void MoveToInactive(GameObject human)
    {
        human.SetActive(false);
        RemoveFromActiveHumanList(human);
    }

    internal void RemoveFromActiveHumanList(GameObject human)
    {
        if (_activeHuman.Contains(human))
            {
            _activeHuman.Remove(human);
        }
    }

}



