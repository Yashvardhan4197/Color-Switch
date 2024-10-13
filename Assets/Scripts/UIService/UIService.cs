
using UnityEngine;

public class UIService
{
    private UIController mainMenuController;

    public UIService(MainMenuView mainMenuView,ScoreView scoreView)
    {
        mainMenuController = new UIController(mainMenuView, scoreView);
    }

    public UIController GetMainMenuController() => mainMenuController;




}
