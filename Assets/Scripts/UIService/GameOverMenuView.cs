
using TMPro;
using Unity.VisualScripting;
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

    private void OnDestroy()
    {
        GameService.Instance.StopGame -= OpenMenu;
        UIController.OnDestroy();
    }

    private void RestartGame()
    {
        GameService.Instance.RestartGame?.Invoke();
        UIController.DisableComponent(canvasGroup);
    }

    public void SetControlller(UIController controller)
    {
        UIController = controller;
    }

    public void OpenMenu()
    {
        UIController.EnableComponent(canvasGroup);
        UIController.UpdateHighScore();
    }

    public CanvasGroup GetCanvasGroup() => canvasGroup;

    public TextMeshProUGUI GetHighScoreText()=> HighScore;


}
