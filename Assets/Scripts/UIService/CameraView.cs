using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] Transform playerTransform;


    private void Update()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            transform.position=new Vector3(transform.position.x,playerTransform.position.y,transform.position.z);
        }
    }
}
