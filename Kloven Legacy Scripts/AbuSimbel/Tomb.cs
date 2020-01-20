using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    public Transform tomb;
    public float openSpeed;
    public int timeInteracted;
    public int numberOfMummies;

    Interactable interactable;
    GameObject golemSpawner;
    GameObject mummySpawner;
    GameObject anubisSpawner;
    GameObject mummies;
    GameObject anubis;
    GameObject aiden;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        timeInteracted = 0;
        numberOfMummies = 0;
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
        aiden = GameObject.Find("Player");

        //First time interacting with the tomb
        if (tomb.transform.position.z >= -6.5f && timeInteracted == 1)
        {
            tomb.transform.Translate(Vector3.left * openSpeed * Time.deltaTime);
            aiden.gameObject.SendMessage("SorryFightTheMummiesSound");
            mummySpawner = GameObject.Find("Spawnpoint");
            mummySpawner.gameObject.SendMessage("SpawnTheMummies");
        }
        else if (numberOfMummies == 4 && interactable.interact && timeInteracted == 1)
        {
            timeInteracted++;
        }

        if (numberOfMummies == 3)
        {
            aiden.gameObject.SendMessage("OpenItAgainSound");
        }
        Debug.Log(timeInteracted);

        //Second Time Interacting With The Tomb
        if (tomb.transform.position.z >= -7.5f && timeInteracted == 2)
        {
            if (numberOfMummies == 4)
            {
                //Anubis appears and Mummies spawn again
                tomb.transform.Translate(Vector3.left * openSpeed * 4 * Time.deltaTime);
                aiden.gameObject.SendMessage("AnubisSpellSound");
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
            aiden.gameObject.SendMessage("GolemAppearsSound");
            golemSpawner = GameObject.Find("Spawnpoint Golem");
            golemSpawner.gameObject.SendMessage("SpawnTheGolem");
        }
    }

    public void NumberOfMummiesAlive()
    {
        numberOfMummies++;
        Debug.Log(""+numberOfMummies);
    }
}
