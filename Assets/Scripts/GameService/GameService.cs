using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    //View
    [SerializeField] MainMenuView mainMenuView;
    [SerializeField] ScoreView scoreView;
    //Services
    public UIService UIService { get; set;}
    //[SerializeField] PlayerService PlayerService;

    private void Start()
    {
        UIService=new UIService(mainMenuView,scoreView);
    }

}
