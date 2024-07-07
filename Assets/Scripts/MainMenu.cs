using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _play;
    [SerializeField]
    private Button _quit;

    void Start()
    {
        _play.onClick.AddListener(() => GameManager.Instance.UpdateState(GameStates.GamePlay));
        _quit.onClick.AddListener(() => GameManager.Instance.UpdateState(GameStates.ApplicationExit));
    }

}
