using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{

    private void Start()
    {
        GameService.Instance.StartGame += OnGameStart;
        GameService.Instance.RestartGame += OnGameStart;
    }

    public void OnGameStart()
    {
        transform.position=new Vector3(0,0,-2f);
    }

    private void Update()
    {
        if (GameService.Instance.PlayerService.GetPlayerController().GetPlayerTransform().position.y > transform.position.y)
        {
            transform.position=new Vector3(transform.position.x,GameService.Instance.PlayerService.GetPlayerController().GetPlayerTransform().position.y,transform.position.z);
        }
    }
}
