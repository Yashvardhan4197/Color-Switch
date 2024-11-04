
using UnityEngine;

public class ObstacleSpawnerView : MonoBehaviour
{
    private ObstacleSpawnerController obstacleController;
    [SerializeField] float OffsetY=4.5f;

    private void Update()
    {
        obstacleController?.Update();
    }

    public void SetController(ObstacleSpawnerController obstacleController)
    {
        this.obstacleController=obstacleController;
        obstacleController.SetOffset(OffsetY);

    }

    public void DestroyEnemy(GameObject target)
    {
        Destroy(target);
    }
  
}
