
using UnityEngine;

public class BlueState : IState
{
    public PlayerController Owner { get; set; }
    private PlayerStateMachine stateMachine;
    public string tag { get; set; }
    public Color color { get; set; }

    public BlueState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void OnStateEnter()
    {
        tag = "BLUE";
        color= Color.blue;
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

    public void ChangeTag()
    {
        throw new System.NotImplementedException();
    }
}
