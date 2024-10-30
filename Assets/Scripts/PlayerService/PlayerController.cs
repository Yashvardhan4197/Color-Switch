

using System;
using System.Drawing;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private ColorDataSO colorData;
    private bool firstJump = true;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        SpawnParticleSystem();
        GameService.Instance.StartGame += EnableCanvasGroup;
        GameService.Instance.StartGame += ChangeColor;
        playerView.SetController(this);
        spriteRenderer = playerView.GetSpriteRenderer();
        rb2D=playerView.gameObject.GetComponent<Rigidbody2D>();
        GameService.Instance.RestartGame += OnGameRestart;
    }

    private void SpawnParticleSystem()
    {
        playerView.GetParticleSystem().GetComponent<ParticleSystem>().Play();
    }

    public void EnableCanvasGroup()
    {
        playerView.GetCanvasGroup().alpha = 1;
        playerView.GetCanvasGroup().interactable = true;
        playerView.GetCanvasGroup().blocksRaycasts = true;
    }

    public void Update()
    {

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
        GameService.Instance.StartGame-= ChangeColor;
        GameService.Instance.RestartGame -= OnGameRestart;
    }

    public void ChangeColor()
    {
        colorData=GameService.Instance.GetRandomColor();
        spriteRenderer.color = colorData.color;
        var mainModule = playerView.GetParticleSystem().GetComponent<ParticleSystem>().main;
        mainModule.startColor = colorData.color;
    }

    public ColorDataSO GetCurrentColor()=> colorData;

    public Transform GetPlayerTransform()=>playerView.gameObject.transform;

    public void GameOver()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 0;
        firstJump = true;
        GameService.Instance.StopGame?.Invoke();
    }

    public void OnGameRestart()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 0;
        firstJump = true;
        playerView.GetParticleSystem().GetComponent<ParticleSystem>().Stop();
        SpawnParticleSystem();
    }
}

