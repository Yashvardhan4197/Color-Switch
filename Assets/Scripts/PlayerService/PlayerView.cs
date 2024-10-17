
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float JumpSpeed;
    [SerializeField] CanvasGroup canvasGroup;
    private void Start()
    {
        rb2D.gravityScale = 0f;
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        if (GameService.Instance.gameStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {

              playerController?.PerformJump();

            }
        }
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //GameService Game Over;
            Debug.Log("Game Over");
        }
    }

    public CanvasGroup GetCanvasGroup() { return canvasGroup; }

    public float GetJumpSpeed() => JumpSpeed;
}   
