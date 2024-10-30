using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] ColorDataSO ColorData;

    public ColorDataSO GetColorData()
    {
        return ColorData;
    }
}
