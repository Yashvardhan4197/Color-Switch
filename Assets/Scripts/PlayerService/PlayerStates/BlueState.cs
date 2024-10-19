
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

    private void ChangeColor(Color color)
    {
        var mainModule = Owner.particleTrail.GetComponent<ParticleSystem>().main;
        mainModule.startColor = color;
    }

    public void OnStateEnter()
    {
        tag = "BLUE";
        color= Color.cyan;
        ChangeColor(color);
    }


    public void OnStateExit()
    {

    }

    public void Update()
    {

    }

}
