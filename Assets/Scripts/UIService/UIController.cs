using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private MainMenuView mainMenuView;
    private ScoreView scoreView;
    private int score;
    public UIController(MainMenuView mainMenuView,ScoreView scoreView)
    {
        this.mainMenuView = mainMenuView;
        this.scoreView = scoreView;
        mainMenuView.SetController(this);
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreView.GetScoreText().text = this.score.ToString();
    }

    public void DisableComponent(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

}
