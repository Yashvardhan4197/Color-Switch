
using UnityEngine;

public class CameraView : MonoBehaviour
{
    private void Start()
    {
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    private void Update()
    {
        if (GameService.Instance.PlayerService.GetPlayerController().GetPlayerTransform().position.y > transform.position.y)
        {
            transform.position=new Vector3(transform.position.x,GameService.Instance.PlayerService.GetPlayerController().GetPlayerTransform().position.y,transform.position.z);
        }
    }

    public void OnGameStart()
    {
        transform.position = new Vector3(0, 0, -2f);
    }

}
