using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuView : MonoBehaviour
{
    private UIController UIController;
    [SerializeField] Button RestartButton;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI HighScore;

    private void Start()
    {
        RestartButton.onClick.AddListener(RestartGame);
        GameService.Instance.StopGame += OpenMenu;
    }

    public void SetControlller(UIController controller)
    {
        UIController = controller;
    }

    private void RestartGame()
    {
        GameService.Instance.RestartGame?.Invoke();
        UIController.DisableComponent(canvasGroup);
    }

    public void OpenMenu()
    {
        UIController.EnableComponent(canvasGroup);
        UIController.UpdateHighScore();
    }

    public CanvasGroup GetCanvasGroup() => canvasGroup;

    private void OnDestroy()
    {
        GameService.Instance.StopGame -= OpenMenu;
    }

    public TextMeshProUGUI GetHighScoreText()=> HighScore;
}
