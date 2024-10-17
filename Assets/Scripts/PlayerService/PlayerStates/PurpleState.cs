
public class PurpleState : IState
{
    public PlayerController Owner { get; set; }
    private PlayerStateMachine stateMachine;

    public PurpleState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public void OnStateEnter()
    {
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

