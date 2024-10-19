using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private MainMenuView mainMenuView;
    private ScoreView scoreView;
    private int score;
    private int HighScore;
    public UIController(MainMenuView mainMenuView,ScoreView scoreView,GameOverMenuView gameOverView)
    {
        this.mainMenuView = mainMenuView;
        this.scoreView = scoreView;
        mainMenuView.SetController(this);
        gameOverView.SetControlller(this);
        DisableComponent(gameOverView.GetCanvasGroup());
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreView.GetScoreText().text = this.score.ToString();
    }
    public void IncrementScore()
    {
        score++;
        scoreView.GetScoreText().text = this.score.ToString();
        if(score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore",HighScore);
        }
    }

    public int GetCurrentScore() => score;

    public void DisableComponent(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public void EnableComponent(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void OnGameStart()
    {
        score = 0;
        UpdateScore(score);
    }
    ~UIController()
    {
        GameService.Instance.StartGame -= OnGameStart;
        GameService.Instance.RestartGame -= OnGameStart;
    }
}
