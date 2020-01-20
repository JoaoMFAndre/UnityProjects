using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    public Transform golemCinematicPosition;
    public Transform golemCinematic;
    public Transform exitCinematicPosition;
    public Transform exitCinematic;

    public GameObject mainCamera;
    public GameObject cinematicCamera;
    public GameObject crosshair;

    public bool finalDoorOpening;

    // Start is called before the first frame update
    void Start()
    {
        cinematicCamera.SetActive(false);
        mainCamera.SetActive(true);
        finalDoorOpening = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Golem Cinematic
        if (GameObject.Find("Golem(Clone)") != null)
        {
            cinematicCamera.SetActive(true);
            mainCamera.SetActive(false);
            crosshair.SetActive(false);
            StartCoroutine(LerpFromTo(cinematicCamera.transform.position, golemCinematicPosition.transform.position, 1f));

            Vector3 lTargetDir = golemCinematic.position - cinematicCamera.transform.position;
            lTargetDir.y = 0.0f;
            cinematicCamera.transform.rotation = Quaternion.RotateTowards(cinematicCamera.transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 4);
        }
        */
        //Final Door Opening Cinematic
        if (Input.GetKey(KeyCode.V))
        {
            cinematicCamera.SetActive(true);
            mainCamera.SetActive(false);
            crosshair.SetActive(false);
            StartCoroutine(LerpFromTo(cinematicCamera.transform.position, exitCinematicPosition.transform.position, 1f));

            Vector3 lTargetDir = exitCinematic.position - cinematicCamera.transform.position;
            lTargetDir.y = 0.0f;
            cinematicCamera.transform.rotation = Quaternion.RotateTowards(cinematicCamera.transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 4);
        }

        else if (!Input.GetKey(KeyCode.V))
        {
            cinematicCamera.transform.position = mainCamera.transform.position;
            cinematicCamera.SetActive(false);
            mainCamera.SetActive(true);
            crosshair.SetActive(true);
        }

    }

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime * 2)
        {
            cinematicCamera.transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        cinematicCamera.transform.position = pos2;
    }
    /*
    public void GolemCinematicEnd()
    {
        cinematicCamera.transform.position = mainCamera.transform.position;
        cinematicCamera.SetActive(false);
        mainCamera.SetActive(true);
        crosshair.SetActive(true);
    }*/
}
