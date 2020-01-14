using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform pivotObj;
    public Vector3 target_Offset;


    private void Start()
    {
        pivotObj = GameObject.Find("PivotObj").transform;
        target_Offset = transform.position - pivotObj.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, pivotObj.position + target_Offset, 0.1f);
    }
}
