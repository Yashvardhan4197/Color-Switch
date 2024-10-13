using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    private UIController mainMenuController;
    [SerializeField] Button StartButton;
    [SerializeField] CanvasGroup canvasGroup;
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        //Game Start Action;
        GameService.Instance.StartGame?.Invoke();
        mainMenuController.DisableComponent(canvasGroup);
    }

    public void SetController(UIController mainMenuController)
    {
        this.mainMenuController = mainMenuController;
    }

    void Update()
    {
        
    }
}
