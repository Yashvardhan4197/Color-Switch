
using UnityEngine;

public class PurpleState : IState
{
    public PlayerController Owner { get; set; }
    private PlayerStateMachine stateMachine;
    public string tag { get; set; }
    public Color color { get; set; }

    public PurpleState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public void OnStateEnter()
    {
        tag = "PURPLE";
        color = new Color(0.5f, 0f, 0.5f);
        //throw new System.NotImplementedException();
    }

    public void OnStateExit()
    {
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        //throw new System.NotImplementedException();
    }
}

