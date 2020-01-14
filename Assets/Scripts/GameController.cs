using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   
    private int ringStartCount;

    [HideInInspector] public float crushCounter = 0;

    private LevelStatusView levelStatusView;

    private void Start()
    {
        ringStartCount = GameObject.Find("ParentRing").transform.childCount;
        levelStatusView = GameObject.Find("Canvas").transform.GetComponent<LevelStatusView>();
    }


    private void FixedUpdate()
    {
        //Debug.Log(levelStatusView.RingCounter);
        if (crushCounter != 0)
        {
            levelStatusView.RingCounter = Mathf.Lerp(levelStatusView.RingCounter, crushCounter / ringStartCount, 0.1f);
        }
        if (levelStatusView.RingCounter>0.9f)
        {
            Camera.main.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
        }
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
