using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorManager : MonoBehaviour
{
    public int RotateSpeed;
    public Direction direction=Direction.LEFT;
    private void Update()
    {
        if (direction == Direction.LEFT)
        {
            transform.Rotate(0, 0, RotateSpeed);
        }
        else
        {
            transform.Rotate(0, 0, RotateSpeed*-1);
        }
    }
}

public enum Direction
{
    LEFT,
    RIGHT
}
