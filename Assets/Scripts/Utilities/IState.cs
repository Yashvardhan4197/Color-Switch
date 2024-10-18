
using UnityEngine;

public interface IState 
{
    public PlayerController Owner { get; set; }
    public string tag {  get; set; }
    public Color color { get; set; }
    public void OnStateEnter();
    public void OnStateExit();
    public void Update();

}
