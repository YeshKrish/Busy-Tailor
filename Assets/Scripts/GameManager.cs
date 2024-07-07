using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
    MainMenu,
    GamePlay,
    ApplicationExit
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

        DontDestroyOnLoad(this.gameObject);
    }

    private GameStates _currentState;

    private void Start()
    {
        UpdateState(GameStates.MainMenu);

    }

    public void UpdateState(GameStates state)
    {
        _currentState = state;
        switch (state)
        {
            case GameStates.MainMenu:
                break;
            case GameStates.GamePlay:
                StartGame();
                break;
            case GameStates.ApplicationExit:
                QuitApplication();
                break;
            default:
                break;
        }
    }

    private void QuitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }

    private void StartGame()
    {
        SceneManager.LoadScene("BusyTailor");
    }

    internal void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
