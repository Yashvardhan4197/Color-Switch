
public interface IState 
{
    public PlayerController Owner { get; set; }

    public void OnStateEnter();
    public void OnStateExit();
    public void Update();
}
