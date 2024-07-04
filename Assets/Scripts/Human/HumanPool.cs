using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusyTailor_Human
{
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
                foreach (GameObject human in _humansList)
                {
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
        internal void RemoveFromActiveHumanList(GameObject human)
        {
            if (_activeHuman.Contains(human))
                {
                _activeHuman.Remove(human);
            }
    }

    }


}
