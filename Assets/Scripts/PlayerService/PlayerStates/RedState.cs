
using UnityEngine;

public class RedState : IState
{
    public PlayerController Owner { get; set; }
    private PlayerStateMachine stateMachine;
    public string tag { get; set; }
    public Color color { get; set; }

    public RedState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void OnStateEnter()
    {
        tag = "RED";
        color = new Color(1f, 0, 0.4882569f);
        ChangeColor(color);
    }

    private void ChangeColor(Color color)
    {
        var mainModule = Owner.particleTrail.GetComponent<ParticleSystem>().main;
        mainModule.startColor = color;
    }

    public void OnStateExit()
    {
       
    }

    public void Update()
    {
        
    }
}

