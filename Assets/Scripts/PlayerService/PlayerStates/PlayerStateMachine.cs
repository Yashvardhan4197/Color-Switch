
using System.Collections.Generic;

public class PlayerStateMachine
{
    private PlayerController Owner;
    private Dictionary<ColorStates,IState> states=new Dictionary<ColorStates, IState>();
    private IState currentState;
    public PlayerStateMachine(PlayerController controller)
    {
        Owner = controller;
        CreateStates();
        SetOwner();
    }
    private void CreateStates()
    {
        states.Add(ColorStates.PINK, new RedState(this));
        states.Add(ColorStates.YELLOW,new YellowState(this));  
        states.Add(ColorStates.BLUE,new BlueState(this));
        states.Add(ColorStates.PURPLE,new PurpleState(this));
    }
    
    private void SetOwner()
    {
        foreach(IState state in states.Values)
        {
            state.Owner = Owner;
        }
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(ColorStates state)
    {
        currentState?.OnStateExit();
        currentState = states[state];
        currentState.OnStateEnter();
    }

    public int TotalStates()=>states.Count;
}
