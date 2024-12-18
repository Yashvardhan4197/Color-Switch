
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float JumpSpeed;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject particleTrail;
    private void Start()
    {
        rb2D.gravityScale = 0f;
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        if (GameService.Instance.CheckIfGameStarted()== true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                playerController?.PerformJump();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "CHANGER")
        {
            playerController.ChangeColor();
            Destroy(collision.gameObject);
            return;
        }
        
        if(collision.tag=="BOTTOM")
        {
            GameService.Instance.StopGame?.Invoke();
            return;
        }
        if (collision.tag == "POINT")
        {
            GameService.Instance.UIService.GetUIController().IncrementScore();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != playerController.GetCurrentTag())
        {
            playerController.GameOver();
            return;
        }

    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public CanvasGroup GetCanvasGroup() { return canvasGroup; }

    public float GetJumpSpeed() => JumpSpeed;

    public SpriteRenderer GetSpriteRenderer()=> spriteRenderer;

    public GameObject GetParticleSystem() => particleTrail;
}   
