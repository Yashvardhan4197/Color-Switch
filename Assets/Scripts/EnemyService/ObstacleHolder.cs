
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] GameObject StarScore;

    public void EnableScore()
    {
        StarScore.SetActive(true);
    }

    public void DisableScore()
    {
        StarScore?.SetActive(false);
    }

}
