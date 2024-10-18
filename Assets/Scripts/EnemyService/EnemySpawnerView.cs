using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    private EnemySpawnerController enemyController;

    public void SetController(EnemySpawnerController enemyController)
    {
        this.enemyController=enemyController;
    }

    private void Update()
    {
        enemyController?.Update();
    }


    
}
