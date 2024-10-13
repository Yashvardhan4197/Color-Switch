
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private bool firstJump;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float JumpSpeed;
    [SerializeField] CanvasGroup canvasGroup;
    private void Start()
    {
        firstJump = true;
        rb2D.gravityScale = 0f;
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        if (GameService.Instance.gameStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {

              PerformJump();

            }
        }
    }

    private void PerformJump()
    {
        if(firstJump)
        {
            firstJump=false;
            rb2D.gravityScale = 2;
        }

        rb2D.velocity = JumpSpeed * Vector3.up;
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

}
