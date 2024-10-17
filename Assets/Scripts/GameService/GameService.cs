
using UnityEngine;
using UnityEngine.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    //View
    [SerializeField] MainMenuView mainMenuView;
    [SerializeField] ScoreView scoreView;
    [SerializeField] PlayerView playerView;
    [SerializeField] GameObject StartPostion;
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
        //Remember to DestroyExtraObjects
        StartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        gameStarted = true;
        playerView.gameObject.SetActive(true);
        playerView.gameObject.transform.position = StartPostion.transform.position;
    }

    private void OnDestroy()
    {
        StartGame -= OnGameStart;
    }

}
