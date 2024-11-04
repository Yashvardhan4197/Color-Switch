
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerView>() == true)
        {
            GameService.Instance.StopGame?.Invoke();
        }
        else if (collision.gameObject.transform?.parent.transform?.parent.GetComponent<ObstacleHolder>()!=null)
        {
            Debug.Log("I Happened");
            GameService.Instance.ObstacleSpawnerService.GetObstacleSpawnerController().DisableObstacle(collision.gameObject.transform.parent.transform.parent.gameObject);
        }
        
    }
}
