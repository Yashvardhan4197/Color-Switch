
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerView>() == true)
        {
            GameService.Instance.StopGame?.Invoke();
        }
        else if (collision.gameObject.transform?.parent.GetComponent<ObstacleHolder>()!=null)
        {
            GameService.Instance.EnemySpawnerService.GetEnemySpawnerController().DisableObstacle(collision.gameObject.transform.parent.gameObject);
        }
        

    }
}
