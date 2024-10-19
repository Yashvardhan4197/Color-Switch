
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    private EnemySpawnerController enemyController;

    private void Update()
    {
        enemyController?.Update();
    }

    public void SetController(EnemySpawnerController enemyController)
    {
        this.enemyController=enemyController;
    }

    public void DestroyEnemy(GameObject target)
    {
        Destroy(target);
    }
  
}
