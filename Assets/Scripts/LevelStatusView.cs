using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatusView : MonoBehaviour
{
    [HideInInspector] public float RingCounter = 0;

   private void FixedUpdate()
    {
        transform.GetChild(1).GetComponent<Image>().fillAmount = RingCounter;
    }
}
