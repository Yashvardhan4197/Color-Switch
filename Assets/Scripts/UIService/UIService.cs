
using UnityEngine;

public class UIService
{
    private UIController UIController;

    public UIService(MainMenuView mainMenuView,ScoreView scoreView,GameOverMenuView gameOverMenuView)
    {
        UIController = new UIController(mainMenuView, scoreView, gameOverMenuView);
    }

    public UIController GetUIController() => UIController;




}
