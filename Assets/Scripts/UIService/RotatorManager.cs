using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorManager : MonoBehaviour
{
    public int RotateSpeed;
    private void Update()
    {
        transform.Rotate(0, 0, RotateSpeed);
    }
}
