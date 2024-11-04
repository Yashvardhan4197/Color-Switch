
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    [SerializeField] ColorDataSO ColorData;

    public ColorDataSO GetColorData()
    {
        return ColorData;
    }
}
