
public class EnemySpawnerService
{
    private EnemySpawnerController enemyController;
    public EnemySpawnerService(EnemySpawnerView enemyView, UnityEngine.GameObject[] obstacles)
    {
        enemyController=new EnemySpawnerController(enemyView,obstacles);
    }

    public EnemySpawnerController GetEnemySpawnerController() { return  enemyController; }
}
