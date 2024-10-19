
using UnityEngine;
using UnityEngine.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    //View
    [SerializeField] MainMenuView mainMenuView;
    [SerializeField] ScoreView scoreView;
    [SerializeField] PlayerView playerView;
    [SerializeField] GameOverMenuView gameOverMenuView;
    [SerializeField] EnemySpawnerView enemySpawnerView;

    //Services
    public UIService UIService { get; set;}
    public PlayerService PlayerService { get; set;}
    public EnemySpawnerService EnemySpawnerService { get; set;}

    //Action
    public UnityAction StartGame;
    public UnityAction RestartGame;
    public UnityAction StopGame;
    public bool gameStarted = false;

    //Data
    [SerializeField] public GameObject StartPostion;
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] public GameObject ColorChanger;
    [SerializeField] BoxCollider2D ground;

    private void Start()
    {
        UIService=new UIService(mainMenuView,scoreView, gameOverMenuView);
        PlayerService=new PlayerService(playerView);
        EnemySpawnerService = new EnemySpawnerService(enemySpawnerView,Obstacles);
        StartGame += OnGameStart;
        RestartGame += OnGameRestart;
        StopGame += OnGameStop;
        
    }

    public void OnGameStart()
    {
        Time.timeScale = 1f;
        gameStarted = true;
        playerView.gameObject.SetActive(true);
        playerView.gameObject.transform.position = StartPostion.transform.position;
    }

    private void OnDestroy()
    {
        StartGame -= OnGameStart;
        RestartGame-= OnGameRestart;
    }

    public void OnGameRestart()
    {
        Time.timeScale = 1f;
        playerView.gameObject.transform.position=StartPostion.transform.position;
    }

    public void OnGameStop()
    {
        Time.timeScale = 0f;
    }
}
