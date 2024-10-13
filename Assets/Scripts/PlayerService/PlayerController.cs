

public class PlayerController
{
    private PlayerView playerView;

    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        GameService.Instance.StartGame += EnableCanvasGroup;
    }

    public void EnableCanvasGroup()
    {
        playerView.GetCanvasGroup().alpha = 1;
        playerView.GetCanvasGroup().interactable = true;
        playerView.GetCanvasGroup().blocksRaycasts = true;
    }


    ~PlayerController()
    {
        GameService.Instance.StartGame -= EnableCanvasGroup;
    }
}

