
using UnityEngine;

public class UIService
{
    private UIController UIController;

    public UIService(MainMenuView mainMenuView,ScoreView scoreView)
    {
        UIController = new UIController(mainMenuView, scoreView);
    }

    public UIController GetUIController() => UIController;




}
