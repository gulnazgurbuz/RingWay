using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PivotController : MonoBehaviour
{
    private bool pivotMove = false;

    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private Transform parentRing;
    private GameController gameController;

    [HideInInspector] public bool pivotCrush = false;



    private void Start()
    {
        parentRing = GameObject.Find("ParentRing").transform;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPosition = transform.position;
            targetPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 2);
            pivotMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (pivotMove && !pivotCrush)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
        if (parentRing.childCount == 0)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RingItem")
        {
            pivotCrush = true;
            //transform.GetComponent<Animator>().enabled = true;
            //transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 0.5f), 0.1f);
            StartCoroutine(RestartLevel());
        }

        if (other.tag == "RingDraft")
        {
            other.gameObject.transform.parent.transform.GetComponent<Animator>().enabled = true;
            StartCoroutine(DeleteRing(other.gameObject.transform.parent.gameObject));
            gameController.crushCounter++;
            if (transform.childCount != 0)
            {
                gameController.crushCounter -= ((float)transform.childCount - 1) / (float)transform.childCount;
            }
        }
    }

    private IEnumerator DeleteRing(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        Destroy(obj);
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
    }
}
