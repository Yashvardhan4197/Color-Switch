
using UnityEngine;
using UnityEngine.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    //View
    [SerializeField] MainMenuView mainMenuView;
    [SerializeField] ScoreView scoreView;
    [SerializeField] PlayerView playerView;
    [SerializeField] GameOverMenuView gameOverMenuView;
    [SerializeField] ObstacleSpawnerView enemySpawnerView;

    //Services
    private UIService uIService;
    private PlayerService playerService;
    private ObstacleSpawnerService enemySpawnerService;
    public UIService UIService {  get { return uIService; } }
    public PlayerService PlayerService { get { return playerService; } }
    public ObstacleSpawnerService EnemySpawnerService { get { return enemySpawnerService; } }

    //Action
    public UnityAction StartGame;
    public UnityAction RestartGame;
    public UnityAction StopGame;
    private bool gameStarted = false;

    //Data
    [SerializeField] GameObject StartPostion;
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] GameObject ColorChanger;
    [SerializeField] BoxCollider2D ground;
    [SerializeField] ColorDataSO[] colorDatas;

    private void Start()
    {
        uIService=new UIService(mainMenuView,scoreView, gameOverMenuView);
        playerService=new PlayerService(playerView);
        enemySpawnerService = new ObstacleSpawnerService(enemySpawnerView,Obstacles);
        StartGame += OnGameStart;
        RestartGame += OnGameRestart;
        StopGame += OnGameStop;
        
    }

    public void OnGameStart()
    {
        Time.timeScale = 1f;
        GameService.Instance.SetCheckGameStarted(true);
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

    public Transform GetStartPosition() => StartPostion.transform;

    public GameObject GetColorChanger() => ColorChanger;

    public bool CheckIfGameStarted() => gameStarted;

    public void SetCheckGameStarted(bool change)=> gameStarted = change;

    public ColorDataSO GetRandomColor()
    {
        ColorDataSO colorData= colorDatas[Random.Range(0,colorDatas.Length)];
        return colorData;
    }
}
