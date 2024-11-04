
using UnityEngine;

public class UIController
{
    private MainMenuView mainMenuView;
    private ScoreView scoreView;
    private GameOverMenuView GameOverMenuView;
    private int score;
    private int HighScore;

    public UIController(MainMenuView mainMenuView,ScoreView scoreView,GameOverMenuView gameOverView)
    {
        this.mainMenuView = mainMenuView;
        this.scoreView = scoreView;
        GameOverMenuView = gameOverView;
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

    public void UpdateHighScore()
    {
        GameOverMenuView.GetHighScoreText().text = HighScore.ToString();
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

    public int GetHighScore()=>HighScore;

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
        UpdateHighScore();
    }

    public void OnDestroy()
    {
        GameService.Instance.StartGame -= OnGameStart;
        GameService.Instance.RestartGame -= OnGameStart;
    }

}
