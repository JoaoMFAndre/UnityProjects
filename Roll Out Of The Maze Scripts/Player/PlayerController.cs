using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    public float speed;
    public float runSpeed;
    public float jumpStrength;

    public Text countText;
    public Text winText;

    public Rigidbody rb;

    public int count;

    public Transform cameraTransform;

    bool isGrounded;

    public GameObject Door;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;
    public GameObject Door42;
    public GameObject Door5;
    public GameObject Door6;
    public GameObject Door62;
    public GameObject Door7;

    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject spawnPoint5;
    public GameObject spawnPoint6;
    public GameObject spawnPoint7;

    public bool door1IsOpening;
    public bool door2IsOpening;
    public bool door3IsOpening;
    public bool door4IsOpening;
    public bool door5IsOpening;
    public bool door6IsOpening;
    public bool door62IsOpening;
    public bool door7IsOpening;


    public Camera playerCamera;
    public Camera doorCamera;
    public Camera doorCamera2;
    public Camera doorCamera3;
    public Camera doorCamera4;
    public Camera doorCamera5;
    public Camera doorCamera6;
    public Camera doorCamera62;
    public Camera doorCamera7;

    public AudioClip gateOpening;
    public AudioClip collectCoin;
    public AudioClip wallHit;


    AudioSource audio;

    public Transform _AudioListener;

    public AudioClip engineStartClip;
    public AudioClip engineLoopClip;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent <AudioSource>();
        count = 0;
        SetCountText();
        playerCamera.enabled = true;
        doorCamera.enabled = false;
        doorCamera2.enabled = false;
        doorCamera3.enabled = false;
        doorCamera4.enabled = false;
        doorCamera5.enabled = false;
        doorCamera6.enabled = false;
        doorCamera62.enabled = false;
        doorCamera7.enabled = false;
        // attach audio listner to camera
        _AudioListener.parent = playerCamera.transform;

        // align audio listener to camera (do after parent)
        _AudioListener.localPosition = Vector3.zero;
        _AudioListener.localRotation = Quaternion.identity;

    }

    //Check if Player is Touching the Ground or Any Traps
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            audio.clip = wallHit;
            audio.Play();
        }

        if (collision.gameObject.tag == "Trap")
        {
            rb.transform.position = respawnPoint.transform.position;
            rb.Sleep();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            rb.transform.position = respawnPoint.transform.position;
            rb.Sleep();
        }
    }

    //Check if Player aint Touching the Ground
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector3(0f, jumpStrength, 0f), ForceMode.Impulse);
        }
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        movement = cameraTransform.TransformDirection(movement);

        rb.AddForce(movement.normalized * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)){
            rb.AddForce(movement.normalized * runSpeed * Time.deltaTime);
        }
            OpenDoor();
    }

    //Pick up Collectibles and Falloff the world
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            audio.clip = collectCoin;
            audio.Play();
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("RespawnTrigger"))
        {
            rb.transform.position = respawnPoint.transform.position;
            rb.Sleep();
        }
    }

    void SetCountText()
    {
        countText.text = "x " + count.ToString();
        if(count == 5)
        {
            door1IsOpening = true;
            respawnPoint.transform.position = spawnPoint.transform.position;
            audio.clip = gateOpening;
            audio.Play();
        }
        if (count == 10)
        {
            door2IsOpening = true;
            respawnPoint.transform.position = spawnPoint.transform.position;
            audio.clip = gateOpening;
            audio.Play();
        }
        if (count == 15)
        {
            door3IsOpening = true;
            respawnPoint.transform.position = spawnPoint2.transform.position;
            audio.clip = gateOpening;
            audio.Play();
        }
        if (count == 35)
        {
            door4IsOpening = true;
            respawnPoint.transform.position = spawnPoint3.transform.position;
            audio.clip = gateOpening;
            audio.Play();
        }
        if (count == 40)
        {
            door5IsOpening = true;
            respawnPoint.transform.position = spawnPoint4.transform.position;
            audio.clip = gateOpening;
            audio.Play();
        }
        if (count == 45)
        {
            door6IsOpening = true;
            door62IsOpening = true;
            respawnPoint.transform.position = spawnPoint5.transform.position;
            StartCoroutine(playEngineSound());
        }
        if (count == 50)
        {
            door7IsOpening = true;
            respawnPoint.transform.position = spawnPoint6.transform.position;
            audio.clip = gateOpening;
            audio.Play();

        }
    }

    IEnumerator playEngineSound()
    {
        audio.clip = engineStartClip;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = engineLoopClip;
        audio.Play();
    }

    void OpenDoor()
    {
        //Door x5
        if(door1IsOpening == true && count == 5)
        {

            Destroy(GameObject.Find("Padlock"));
            Door.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = true;
            doorCamera2.enabled = false;
            rb.Sleep();

            // attach audio listner to camera
            _AudioListener.parent = doorCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
  
        }
        if(Door.transform.position.y >= 12f)
        {
            door1IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x5"));

        }

        //Door x10
        if (door2IsOpening == true && count == 10)
        {
            Destroy(GameObject.Find("Padlock 2"));
            Door2.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = true;
            rb.Sleep();
            // attach audio listner to camera
            _AudioListener.parent = doorCamera2.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;

        }
        if (Door2.transform.position.y >= 12f)
        {
            door2IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x10"));
        }

        //Door x15
        if (door3IsOpening == true && count == 15)
        {
            Destroy(GameObject.Find("Padlock 3"));
            Door3.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = true;
            rb.Sleep();
            // attach audio listner to camera
            _AudioListener.parent = doorCamera3.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;

        }
        if (Door3.transform.position.y >= 12f)
        {
            door3IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x15"));
        }

        //Door x35
        if (door4IsOpening == true && count == 35)
        {
            Destroy(GameObject.Find("Padlock 4"));
            Door4.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            Door42.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = true;
            // attach audio listner to camera
            _AudioListener.parent = doorCamera4.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            rb.Sleep();

        }
        if (Door4.transform.position.y >= 12f)
        {
            door4IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x35"));
        }

        //Door x40
        if (door5IsOpening == true && count == 40)
        {
            Destroy(GameObject.Find("Padlock 5"));
            Door5.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = true;
            // attach audio listner to camera
            _AudioListener.parent = doorCamera5.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            rb.Sleep();

        }
        if (Door5.transform.position.y >= 12f)
        {
            door5IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x40"));
        }
        
        //Door x45
        if (door6IsOpening == true && count == 45)
        {
            Destroy(GameObject.Find("Padlock 6"));
            Door6.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = true;
            doorCamera62.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = doorCamera6.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            rb.Sleep();

        }
        if (Door6.transform.position.y >= 12f)
        {
            door6IsOpening = false;
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = false;
            doorCamera62.enabled = false;
        }
        if (door62IsOpening == true && Door6.transform.position.y >= 12f)
        {
            Door62.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = false;
            doorCamera62.enabled = true;
            // attach audio listner to camera
            _AudioListener.parent = doorCamera62.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            rb.Sleep();

        }
        if (Door62.transform.position.y >= 12f)
        {
            door62IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = false;
            doorCamera62.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x45"));
        }

        //Door x50
        if (door7IsOpening == true && count == 50)
        {
            Destroy(GameObject.Find("Padlock 7"));
            Door7.transform.Translate(Vector3.up * Time.deltaTime * 2.3f, Space.World);
            playerCamera.enabled = false;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = false;
            doorCamera62.enabled = false;
            doorCamera7.enabled = true;
            // attach audio listner to camera
            _AudioListener.parent = doorCamera7.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            rb.Sleep();

        }
        if (Door7.transform.position.y >= 12f)
        {
            door7IsOpening = false;
            playerCamera.enabled = true;
            doorCamera.enabled = false;
            doorCamera2.enabled = false;
            doorCamera3.enabled = false;
            doorCamera4.enabled = false;
            doorCamera5.enabled = false;
            doorCamera6.enabled = false;
            doorCamera62.enabled = false;
            doorCamera7.enabled = false;
            // attach audio listner to camera
            _AudioListener.parent = playerCamera.transform;

            // align audio listener to camera (do after parent)
            _AudioListener.localPosition = Vector3.zero;
            _AudioListener.localRotation = Quaternion.identity;
            Destroy(GameObject.Find("x50"));
        }
    }
}  

