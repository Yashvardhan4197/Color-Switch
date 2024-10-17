

using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private PlayerStateMachine playerStateMachine;
    private bool firstJump = true;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        GameService.Instance.StartGame += EnableCanvasGroup;
        playerView.SetController(this);
        playerStateMachine = new PlayerStateMachine(this);
        rb2D=playerView.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer=playerView.GetSpriteRenderer();
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

    public void ChangeColor()
    {
        int random = UnityEngine.Random.Range(0, playerStateMachine.TotalStates());
        ColorStates colorState = (ColorStates)random;
        playerStateMachine.ChangeState(colorState);
        spriteRenderer.color = playerStateMachine.currentState.color;
    }

    public string GetCurrentTag() => playerStateMachine.currentState.tag;
}

