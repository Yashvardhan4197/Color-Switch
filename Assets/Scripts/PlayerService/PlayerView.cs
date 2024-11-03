
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
        if(collision.gameObject.GetComponent<EnemyView>()==null)
        {
            if (collision.tag == "CHANGER")
            {
                playerController.ChangeColor();
                GameService.Instance.EnemySpawnerService.GetEnemySpawnerController().ReturnColorChangerToPool(collision.gameObject);
                return;
            }

            if (collision.tag == "POINT")
            {
                GameService.Instance.UIService.GetUIController().IncrementScore();
                collision.gameObject.SetActive(false);
                return;
            }
        }
        else if(playerController.GetCurrentColor().color !=collision.GetComponent<EnemyView>().GetColorData().color)
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
