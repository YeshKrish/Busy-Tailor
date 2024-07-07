using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button _menuButton;

    void Start()
    {
        _menuButton.onClick.AddListener(() => LoadMainMenu());
    }

    private void LoadMainMenu()
    {
        GameManager.Instance.LoadMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
