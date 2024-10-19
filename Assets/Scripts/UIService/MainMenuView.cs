
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    private UIController mainMenuController;
    [SerializeField] Button StartButton;
    [SerializeField] CanvasGroup canvasGroup;
    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        GameService.Instance.StartGame?.Invoke();
        mainMenuController.DisableComponent(canvasGroup);
    }

    public void SetController(UIController mainMenuController)
    {
        this.mainMenuController = mainMenuController;
    }


}
