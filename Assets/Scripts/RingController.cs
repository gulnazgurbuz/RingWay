using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    private PivotController pivotCont;

    private void Start()
    {
        pivotCont = GameObject.Find("PivotObj").transform.GetComponent<PivotController>();
    }

    private void FixedUpdate()
    {
        if (!pivotCont.pivotCrush)
        {
          transform.Rotate(0, 0, 2);
        }
    }
}
