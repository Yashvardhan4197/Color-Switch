
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
        color = Color.yellow;
        ChangeColor(color);
        //row new System.NotImplementedException();
    }

    private void ChangeColor(Color color)
    {
        var mainModule = Owner.particleTrail.GetComponent<ParticleSystem>().main;
        mainModule.startColor = color;
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

