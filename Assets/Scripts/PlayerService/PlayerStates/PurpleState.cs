
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

    private void ChangeColor(Color color)
    {
        var mainModule = Owner.particleTrail.GetComponent<ParticleSystem>().main;
        mainModule.startColor = color;
    }

    public void OnStateEnter()
    {
        tag = "PURPLE";
        color = new Color(0.4910518f, 0f, 0.9937106f);
        ChangeColor(color);
    }


    public void OnStateExit()
    {

    }

    public void Update()
    {

    }
}

