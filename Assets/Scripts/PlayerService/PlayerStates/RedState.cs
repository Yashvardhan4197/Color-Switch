
public class RedState : IState
{
    public PlayerController Owner { get; set; }
    private PlayerStateMachine stateMachine;

    public RedState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public void OnStateEnter()
    {
       
    }

    public void OnStateExit()
    {
       
    }

    public void Update()
    {
        
    }
}

