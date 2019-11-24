using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    public Transform tomb;
    public float openSpeed;
    public int timeInteracted;

    Interactable interactable;
    GameObject golemSpawner;
    GameObject mummySpawner;
    GameObject anubisSpawner;
    GameObject mummies;
    GameObject anubis;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        timeInteracted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.interact == true && timeInteracted == 0)
        {
            timeInteracted++;
        }
        mummies = GameObject.Find("Mummy(Clone)");
        anubis = GameObject.Find("Anubis(Clone)");

        //First time interacting with the tomb
        if (tomb.transform.position.z >= -6.5f && timeInteracted == 1)
        {
            tomb.transform.Translate(Vector3.left * openSpeed * Time.deltaTime);

            mummySpawner = GameObject.Find("Spawnpoint");
            mummySpawner.gameObject.SendMessage("SpawnTheMummies");
        }
        else if (mummies == null && interactable.interact && timeInteracted == 1)
        {
            timeInteracted++;
        }
    
        Debug.Log(timeInteracted);

        //Second Time Interacting With The Tomb
        if (tomb.transform.position.z >= -7.5f && timeInteracted == 2)
        {
            if (mummies == null)
            {
                //Anubis appears and Mummies spawn again
                tomb.transform.Translate(Vector3.left * openSpeed * Time.deltaTime);
                anubisSpawner = GameObject.Find("Spawnpoint Anubis");
                anubisSpawner.gameObject.SendMessage("SpawnTheAnubis");
            }
        }
        else if (anubis == null && interactable.interact && timeInteracted == 2)
        {
            timeInteracted++;
        }

        //Third Time Interacting With The Tomb
        if (anubis == null && interactable.interact && timeInteracted == 3)
        {
            //Aiden Grabs the Artifact and Golem Appears
            golemSpawner = GameObject.Find("Spawnpoint Golem");
            golemSpawner.gameObject.SendMessage("SpawnTheGolem");
        }
    }
}
