using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent != null)
        {
            Destroy(collision.transform.parent.gameObject);
            Debug.Log("Enemy-Destroyed");
        }
        if (collision.tag == "Player")
        {
            //Start OnGameEND LOGIC
            GameService.Instance.StopGame?.Invoke();
        }
    }
}
