
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    [SerializeField] GameObject StarScore;
    [SerializeField] GameObject ColorChanger;
    public void EnableObjects()
    {
        StarScore.SetActive(true);
        ColorChanger.SetActive(true);
    }

    public void DisableScore()
    {
        StarScore?.SetActive(false);
    }

}
