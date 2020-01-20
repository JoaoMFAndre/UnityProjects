using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip[] Arrival;

    public AudioClip[] tutorialClips;

    public AudioClip[] explainMissionClip;

    public AudioClip[] aidenSkipTutorialClip;
    public AudioClip[] aidenStartTutorialClip;

    public AudioClip[] aidenReadyClip;
    public AudioClip[] aidenNotReadyClip;

    public AudioClip[] getInThePortalClip;

    public AudioClip[] aidenIsReadyClip;
    public AudioClip[] aidenIsNotReadyClip;

    public AudioClip[] welcomeToGizaClips;
    public AudioClip[] meetingTheAliensClips;

    public AudioClip[] firstArtifactGizaClips;
    public AudioClip[] secondArtifactGizaClips;
    public AudioClip[] thirdArtifactGizaClips;

    public AudioClip[] narmerPaletteClips;
    public AudioClip[] ankhCrossClips;
    public AudioClip[] goldenSphinxClips;

    public AudioClip[] insideAbuSimbelClips;
    public AudioClip[] runForDoorClip;

    public AudioClip[] OpenSarcophagousClip;
    public AudioClip[] SorryFightTheMummiesClip;
    public AudioClip[] OpenItAgainClip;
    public AudioClip[] AnubisSpellClip;
    public AudioClip[] GolemAppearsClip;
    public AudioClip[] TakeTheArtifactClip;

    public AudioClip[] BackInTheShipClip;

    public AudioClip[] WelcomeToGreeceClip;

    public AudioClip[] firstArtifactGreeceClips;
    public AudioClip[] secondArtifactGreeceClips;
    public AudioClip[] thirdArtifactGreeceClips;

    public AudioClip[] spartanSwordClips;
    public AudioClip[] goldShieldClips;
    public AudioClip[] goldHelmetClips;

    public AudioClip[] WelcomeToParthenonClip;
    public AudioClip[] foundMazeEntranceClip;

    public AudioClip[] welcomeToMazeClip;
    public AudioClip[] welcomeToMaze2Clip;
    public AudioClip[] meetingTheStatuesClip;
    public AudioClip[] openingFirstDoorClip;
    public AudioClip[] openingMinotaurDoorClip;
    public AudioClip[] enteringMinotaurRoomClip;
    public AudioClip[] afterDefeatingMinotaurClip;

    public GameObject TutorialDialogueOptions;
    public GameObject ReadyToStartMissionOptions;
    public GameObject GetInThePortalOptions;
    public GameObject TutorialProps;

    CombatState combat;

    Item item;

    private int doOnce = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Base0-1Spaceship")
        {
            StartCoroutine(playArrivalClips());
        }

        if (sceneName == "Egypt1-1Giza")
        {
            StartCoroutine(welcomeToGiza());
            combat = GameObject.Find("GM").GetComponent<CombatState>();
            doOnce = 0;
        }

        if (sceneName == "Egypt1-2AbuSimbel")
        {
            StartCoroutine(insideAbuSimbel());
        }

        if (sceneName == "Base0-2SpaceshipPostAbuSimbel")
        {
            StartCoroutine(backInTheShip());
        }

        if (sceneName == "Greece2-1AthensAcropolis")
        {
            StartCoroutine(welcomeToGreece());
        }

        if (sceneName == "Greece2-2Parthenon")
        {
            StartCoroutine(welcomeToParthenon());
        }

        if (sceneName == "Greece2-3Maze")
        {
            StartCoroutine(welcomeToMaze());
            combat = GameObject.Find("GM").GetComponent<CombatState>();
            doOnce = 0;
        }
    }
    
    //SpaceShip
    IEnumerator playArrivalClips()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < Arrival.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = Arrival[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
            TutorialDialogueOptions.SetActive(true);
        }
    }

    IEnumerator aidenSkipTutorial()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenSkipTutorialClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenSkipTutorialClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        TutorialDialogueOptions.SetActive(false);
        StartCoroutine(explainMission());
    }

    IEnumerator aidenStartTutorial()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenStartTutorialClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenStartTutorialClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        TutorialDialogueOptions.SetActive(false);
        StartCoroutine(playTutorialClips());
    }

    IEnumerator playTutorialClips()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < tutorialClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = tutorialClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator explainMission()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < explainMissionClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = explainMissionClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        ReadyToStartMissionOptions.SetActive(true);
    }

    IEnumerator aidenReadyForMission()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenReadyClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenReadyClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        ReadyToStartMissionOptions.SetActive(false);
        StartCoroutine(getInThePortal());
    }

    IEnumerator aidenNotReadyForMission()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenNotReadyClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenNotReadyClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        ReadyToStartMissionOptions.SetActive(false);
        StartCoroutine(getInThePortal());
    }

    IEnumerator getInThePortal()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < getInThePortalClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = getInThePortalClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        GetInThePortalOptions.SetActive(true);
    }

    IEnumerator aidenReady()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenIsReadyClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenIsReadyClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        GetInThePortalOptions.SetActive(false);
    }

    IEnumerator aidenNotReady()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < aidenIsNotReadyClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = aidenIsNotReadyClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        GetInThePortalOptions.SetActive(false);
    }

    //Giza
    IEnumerator welcomeToGiza()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < welcomeToGizaClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = welcomeToGizaClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator meetingTheAliens()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < meetingTheAliensClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = meetingTheAliensClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator firstArtifactGiza()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < firstArtifactGizaClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = firstArtifactGizaClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }

        if (item.name == "AnkhsCross")
        {
            StartCoroutine(ankhCross());
        }
        else if (item.name == "GoldenPhinx")
        {
            StartCoroutine(goldenSphinx());
        }
        else if (item.name == "NarmerPalette")
        {
            StartCoroutine(narmerPalette());
        }
    }

    IEnumerator secondArtifactGiza()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < secondArtifactGizaClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = secondArtifactGizaClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }

        if (item.name == "AnkhsCross")
        {
            StartCoroutine(ankhCross());
        }
        else if (item.name == "GoldenPhinx")
        {
            StartCoroutine(goldenSphinx());
        }
        else if (item.name == "NarmerPalette")
        {
            StartCoroutine(narmerPalette());
        }
    }

    IEnumerator thirdArtifactGiza()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < thirdArtifactGizaClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = thirdArtifactGizaClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator narmerPalette()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < narmerPaletteClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = narmerPaletteClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator ankhCross()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < ankhCrossClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = ankhCrossClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator goldenSphinx()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < goldenSphinxClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = goldenSphinxClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    //AbuSimbel
    IEnumerator insideAbuSimbel()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < insideAbuSimbelClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = insideAbuSimbelClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator runForDoor()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < runForDoorClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = runForDoorClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator openSarcophagous()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < OpenSarcophagousClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = OpenSarcophagousClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator sorryFightTheMummies()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < SorryFightTheMummiesClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = SorryFightTheMummiesClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator openItAgain()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < OpenItAgainClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = OpenItAgainClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator anubisSpell()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < AnubisSpellClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = AnubisSpellClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator golemAppears()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < GolemAppearsClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = GolemAppearsClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator takeTheArtifact()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < TakeTheArtifactClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = TakeTheArtifactClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    //SpaceShip 2
    IEnumerator backInTheShip()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < BackInTheShipClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = BackInTheShipClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    //Greece
    IEnumerator welcomeToGreece()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < WelcomeToGreeceClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = WelcomeToGreeceClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator firstArtifactGreece()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < firstArtifactGreeceClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = firstArtifactGreeceClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }

        if (item.name == "Helmet")
        {
            StartCoroutine(goldHelmet());
        }
        else if (item.name == "Shield")
        {
            StartCoroutine(goldShield());
        }
        else if (item.name == "Sword")
        {
            StartCoroutine(spartanSword());
        }
    }

    IEnumerator secondArtifactGreece()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < secondArtifactGreeceClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = secondArtifactGreeceClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }

        if (item.name == "Helmet")
        {
            StartCoroutine(goldHelmet());
        }
        else if (item.name == "Shield")
        {
            StartCoroutine(goldShield());
        }
        else if (item.name == "Sword")
        {
            StartCoroutine(spartanSword());
        }
    }

    IEnumerator thirdArtifactGreece()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < thirdArtifactGreeceClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = thirdArtifactGreeceClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator spartanSword()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < spartanSwordClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = spartanSwordClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator goldShield()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < goldShieldClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = goldShieldClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator goldHelmet()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < goldHelmetClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = goldHelmetClips[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    //Parthenon
    IEnumerator welcomeToParthenon()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < WelcomeToParthenonClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = WelcomeToParthenonClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator foundMazeEntrance()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < foundMazeEntranceClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = foundMazeEntranceClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    //Maze
    IEnumerator welcomeToMaze()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < welcomeToMazeClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = welcomeToMazeClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
        StartCoroutine(welcomeToMaze2());
    }

    IEnumerator welcomeToMaze2()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < welcomeToMaze2Clip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = welcomeToMaze2Clip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator openingFirstDoor()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < openingFirstDoorClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = openingFirstDoorClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator meetingTheStatues()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < meetingTheStatuesClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = meetingTheStatuesClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator openingMinotaurDoor()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < openingMinotaurDoorClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = openingMinotaurDoorClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator enteringMinotaurRoom()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < enteringMinotaurRoomClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = enteringMinotaurRoomClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    IEnumerator afterDefeatingMinotaur()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < afterDefeatingMinotaurClip.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audioSource.clip = afterDefeatingMinotaurClip[i];

            //3.Play Audio
            audioSource.Play();

            //4.Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    // Update is called once per frame
    void Update()
    {
        //SpaceShip
        if (TutorialDialogueOptions.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(aidenStartTutorial());
                TutorialDialogueOptions.SetActive(false);
                TutorialProps.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(aidenSkipTutorial());
                TutorialDialogueOptions.SetActive(false);
                TutorialProps.SetActive(false);
            }
        }

        if (ReadyToStartMissionOptions.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(aidenReadyForMission());
                ReadyToStartMissionOptions.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(aidenNotReadyForMission());
                ReadyToStartMissionOptions.SetActive(false);
            }
        }

        if (GetInThePortalOptions.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(aidenReady());
                GetInThePortalOptions.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(aidenNotReady());
                GetInThePortalOptions.SetActive(false);
            }
        }

        //Giza
        if (combat.inCombat)
        {
            doOnce++;
        }

        if (doOnce == 1)
        {
            StartCoroutine(meetingTheAliens());
        }

        //Maze
        if (combat.inCombat)
        {
            doOnce++;
        }

        if (doOnce == 1)
        {
            StartCoroutine(meetingTheStatues());
        }
    }

    //AbuSimbel
    public void RunForDoor()
    {
        StartCoroutine(runForDoor());
    }

    public void OpenSarcophagousSound()
    {
        StartCoroutine(openSarcophagous());
    }

    public void SorryFightTheMummiesSound()
    {
        StartCoroutine(sorryFightTheMummies());
    }

    public void OpenItAgainSound()
    {
        StartCoroutine(openItAgain());
    }

    public void AnubisSpellSound()
    {
        StartCoroutine(anubisSpell());
    }

    public void GolemAppearsSound()
    {
        StartCoroutine(golemAppears());
    }

    public void TakeTheArtifactSound()
    {
        StartCoroutine(takeTheArtifact());
    }

    //Parthenon
    public void FoundMazeEntranceSound()
    {
        StartCoroutine(foundMazeEntrance());
    }

    //Maze 
    public void OpenFirstDoorSound()
    {
        StartCoroutine(openingFirstDoor());
    }

    public void OpenMinotaurDoorSound()
    {
        StartCoroutine(openingMinotaurDoor());
    }

    public void EnteringMinotaurRoomSound()
    {
        StartCoroutine(enteringMinotaurRoom());
    }

    public void AfterDefeatingMinotaurSound()
    {
        StartCoroutine(afterDefeatingMinotaur());
    }
}