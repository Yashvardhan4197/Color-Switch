

using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private PlayerStateMachine playerStateMachine;
    private bool firstJump = true;
    private Rigidbody2D rb2D;
    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        GameService.Instance.StartGame += EnableCanvasGroup;
        playerView.SetController(this);
        playerStateMachine = new PlayerStateMachine(this);
        rb2D=playerView.gameObject.GetComponent<Rigidbody2D>();
    }

    public void EnableCanvasGroup()
    {
        playerView.GetCanvasGroup().alpha = 1;
        playerView.GetCanvasGroup().interactable = true;
        playerView.GetCanvasGroup().blocksRaycasts = true;
    }

    public void Update()
    {
        playerStateMachine.Update();
    }

    public void PerformJump()
    {
        if (firstJump)
        {
            firstJump = false;
            rb2D.gravityScale = 2;
        }

        rb2D.velocity = playerView.GetJumpSpeed() * Vector3.up;
    }


    ~PlayerController()
    {
        GameService.Instance.StartGame -= EnableCanvasGroup;
    }

    public void RandomizeState()
    {
        int random = UnityEngine.Random.Range(0, playerStateMachine.TotalStates());
        ColorStates colorState = (ColorStates)random;
        playerStateMachine.ChangeState(colorState);
    }
}

