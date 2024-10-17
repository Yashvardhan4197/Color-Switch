
using UnityEngine;

public class YellowState : IState
{
    private PlayerStateMachine stateMachine;
    public PlayerController Owner { get; set; }
    public string tag { get; set; }
    public Color color { get; set; }

    public YellowState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void OnStateEnter()
    {
        tag = "YELLOW";
        Color color = Color.yellow;
        //row new System.NotImplementedException();
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

