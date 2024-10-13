
using UnityEngine;
using UnityEngine.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    //View
    [SerializeField] MainMenuView mainMenuView;
    [SerializeField] ScoreView scoreView;
    [SerializeField] PlayerView playerView;
    //Services
    public UIService UIService { get; set;}
    public PlayerService PlayerService { get; set;}

    //Action
    public UnityAction StartGame;
    public bool gameStarted = false;

    private void Start()
    {
        UIService=new UIService(mainMenuView,scoreView);
        PlayerService=new PlayerService(playerView);
        StartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        gameStarted = true;
    }

    private void OnDestroy()
    {
        StartGame -= OnGameStart;
    }

}
