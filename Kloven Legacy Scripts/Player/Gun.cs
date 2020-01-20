using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Vector3 targetpoint;
    public Camera Camera;
    Animator animator;
    PlayerMovement playerMovement;

    float cooldown = 0.3f;
    float currentTime;

    public GameObject[] spells; // push your prefabs
    public int currentSpell = 0;
    private int nrSpells;

    private float hole_rotation;
    public float speedV = 1;

    public bool shootingIce;
    public bool shootingShock;

    public GameObject laserPrefab;
    public GameObject shockPrefab;
    public GameObject firePoint;

    public Image spell1;
    public Image spell2;
    public Image spell3;
    public Image spell4;
    public Image spell5;

    public Sprite rock;
    public Sprite fire;
    public Sprite ice;
    public Sprite poison;
    public Sprite electricity;

    public Sprite Unrock;
    public Sprite Unfire;
    public Sprite Unice;
    public Sprite Unpoison;
    public Sprite Unelectricity;

    private GameObject spawnedLaser;
    private GameObject spawnedShock;

    // Start is called before the first frame update
    void Start()
    {
        spell1 = spell1.GetComponent<Image>();
        spell2 = spell2.GetComponent<Image>();
        spell3 = spell3.GetComponent<Image>();
        spell4 = spell4.GetComponent<Image>();
        spell5 = spell5.GetComponent<Image>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        animator = GetComponentInParent<Animator>();
        currentTime = cooldown;
        nrSpells = spells.Length;
        SwitchSpell(currentSpell); // Set default gun
        laserPrefab = spells[2];
        shockPrefab = spells[4];
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        spawnedShock = Instantiate(shockPrefab, firePoint.transform) as GameObject;
        shootingIce = false;
        shootingShock = false;
    }

    void Shoot()
    {
        Ray ray = Camera.ViewportPointToRay(Input.mousePosition);
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit))
        {
            targetpoint = hit.point;
        }
       else
        {
            targetpoint = ray.GetPoint(1000);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && currentSpell != 2 && currentSpell != 4)
        {
            if (playerMovement.lastMoveDirection != playerMovement.moveDirection)
            {
                playerMovement.lastMoveDirection = playerMovement.moveDirection;
                animator.SetLayerWeight(4, 1);
                animator.SetBool("CastingSpell", true);
            }
            else if ((Mathf.Abs(Input.GetAxis("Vertical"))) == 0 && (Mathf.Abs(Input.GetAxis("Horizontal"))) == 0)
            {
                animator.SetLayerWeight(5, 1);
                animator.SetBool("CastingSpell", true);
            }
        }
        else if (currentSpell == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EnableLaser();
            }
            if (Input.GetMouseButton(0))
            {
                UpdateLaser();
            }
            if (Input.GetMouseButtonUp(0))
            {
                DisableLaser();
                
            }
        }

        else if (currentSpell == 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EnableShock();
            }
            if (Input.GetMouseButton(0))
            {
                UpdateShock();
            }
            if (Input.GetMouseButtonUp(0))
            {
                DisableShock();
            }
        }
    }

    void Update()
    {
        if (currentSpell == 0)
        {
            spell1.sprite = rock;
            spell2.sprite = Unfire;
            spell3.sprite = Unice;
            spell4.sprite = Unpoison;
            spell5.sprite = Unelectricity;
        }
        else if (currentSpell == 1)
        {
            spell1.sprite = Unrock;
            spell2.sprite = fire;
            spell3.sprite = Unice;
            spell4.sprite = Unpoison;
            spell5.sprite = Unelectricity;
        }
        else if (currentSpell == 2)
        {
            spell1.sprite = Unrock;
            spell2.sprite = Unfire;
            spell3.sprite = ice;
            spell4.sprite = Unpoison;
            spell5.sprite = Unelectricity;
        }
        else if (currentSpell == 3)
        {
            spell1.sprite = Unrock;
            spell2.sprite = Unfire;
            spell3.sprite = Unice;
            spell4.sprite = poison;
            spell5.sprite = Unelectricity;
        }
        else if (currentSpell == 4)
        {
            spell1.sprite = Unrock;
            spell2.sprite = Unfire;
            spell3.sprite = Unice;
            spell4.sprite = Unpoison;
            spell5.sprite = electricity;
        }

        for (int i = 1; i <= nrSpells; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentSpell = i - 1;

                SwitchSpell(currentSpell);

            }
        }
        if (currentSpell == 0)
        {
            transform.localEulerAngles = new Vector3(-hole_rotation, 0, transform.rotation.z);
        }
        else
        {
            transform.localEulerAngles = new Vector3(hole_rotation, 180, transform.rotation.z);
        }
        Shoot();
        //Hole_rotation();
    }

    

    void SwitchSpell(int index)
    {

        for (int i = 0; i < nrSpells; i++)
        {
            if (i == index)
            {
                spells[i].gameObject.SetActive(true);
            }
            else
            {
                spells[i].gameObject.SetActive(false);
            }
        }
    }

    void Hole_rotation()
    {
        hole_rotation -= speedV * Input.GetAxis("Mouse Y");
        hole_rotation = Mathf.Clamp(hole_rotation, -20, 30);
        transform.localEulerAngles = new Vector3(hole_rotation, 180, transform.rotation.z);
    }

    void EnableLaser()
    {
        

        if (playerMovement.lastMoveDirection != playerMovement.moveDirection)
        {
            playerMovement.lastMoveDirection = playerMovement.moveDirection;
            animator.SetLayerWeight(4, 1);
            animator.SetLayerWeight(5, 0);
            animator.SetBool("CastingLaserSpell", true);
        }
        else if ((Mathf.Abs(Input.GetAxis("Vertical"))) == 0 && (Mathf.Abs(Input.GetAxis("Horizontal"))) == 0)
        {
            animator.SetLayerWeight(5, 1);
            animator.SetLayerWeight(4, 0);
            animator.SetBool("CastingLaserSpell", true);
        }
    }

    void UpdateLaser()
    {
        if (firePoint != null)
        {
            spawnedLaser.transform.position = firePoint.transform.position;
        }
    }

    void DisableLaser()
    {
        spawnedLaser.SetActive(false);
        GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingIceDamage = false;
        shootingIce = false;

        if (playerMovement.lastMoveDirection != playerMovement.moveDirection)
        {
            playerMovement.lastMoveDirection = playerMovement.moveDirection;
            animator.SetLayerWeight(4, 0);
            animator.SetBool("CastingLaserSpell", false);
        }
        else if ((Mathf.Abs(Input.GetAxis("Vertical"))) == 0 && (Mathf.Abs(Input.GetAxis("Horizontal"))) == 0)
        {
            animator.SetLayerWeight(5, 0);
            animator.SetBool("CastingLaserSpell", false);
        }
    }

    void EnableShock()
    {


        if (playerMovement.lastMoveDirection != playerMovement.moveDirection)
        {
            playerMovement.lastMoveDirection = playerMovement.moveDirection;
            animator.SetLayerWeight(4, 1);
            animator.SetLayerWeight(5, 0);
            animator.SetBool("CastingLaserSpell", true);
        }
        else if ((Mathf.Abs(Input.GetAxis("Vertical"))) == 0 && (Mathf.Abs(Input.GetAxis("Horizontal"))) == 0)
        {
            animator.SetLayerWeight(5, 1);
            animator.SetLayerWeight(4, 0);
            animator.SetBool("CastingLaserSpell", true);
        }
    }

    void UpdateShock()
    {
        if (firePoint != null)
        {
            spawnedShock.transform.position = firePoint.transform.position;
        }
    }

    void DisableShock()
    {
        spawnedShock.SetActive(false);
        shootingShock = false;
        if (GameObject.Find("EffectElectricCloud(Clone)") == null)
        {
            GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingElectricDamage = false;
        }

        if (playerMovement.lastMoveDirection != playerMovement.moveDirection)
        {
            playerMovement.lastMoveDirection = playerMovement.moveDirection;
            animator.SetLayerWeight(4, 0);
            animator.SetBool("CastingLaserSpell", false);
        }
        else if ((Mathf.Abs(Input.GetAxis("Vertical"))) == 0 && (Mathf.Abs(Input.GetAxis("Horizontal"))) == 0)
        {
            animator.SetLayerWeight(5, 0);
            animator.SetBool("CastingLaserSpell", false);
        }
    }

    public void ShootProjectile()
    {
        Instantiate(spells[currentSpell], transform.position, transform.rotation);
    }
    public void ShootRay()
    {
        if (currentSpell == 2)
        {
            spawnedLaser.SetActive(true);
            shootingIce = true;
        }
        else if (currentSpell == 4)
        {
            spawnedShock.SetActive(true);
            shootingShock = true;
        }
            
    }

    public void ShootRayEnd()
    {
        if (currentSpell == 2)
        {
            DisableLaser();
        }
        else if (currentSpell == 4)
        {
            DisableShock();
        }
    }
}

