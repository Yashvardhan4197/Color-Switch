
public class ObstacleSpawnerService
{
    private ObstacleSpawnerController obstacleController;
    public ObstacleSpawnerService(ObstacleSpawnerView enemyView, UnityEngine.GameObject[] obstacles)
    {
        obstacleController=new ObstacleSpawnerController(enemyView,obstacles);
    }

    public ObstacleSpawnerController GetObstacleSpawnerController() { return  obstacleController; }
}
