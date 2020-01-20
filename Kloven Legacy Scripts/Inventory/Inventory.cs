using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject GameObject_Showing;

    public int numberOfArtifacts = 0;

    public static Inventory instance;
    public GameObject inventoryUI;
    public GameObject MainCamera;

    GameObject HUD;

    #region
    void Awake()
    {
        if(instance !=  null)
        {
            Debug.LogWarning("More than 1 inventory");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

    private void Start()
    {
        HUD = GameObject.Find("HUD");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            MainCamera.SetActive(!MainCamera.activeSelf);
            Destroy(GameObject_Showing);
        }

        if (inventoryUI.activeSelf)
        {
            HUD.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            HUD.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (GameObject_Showing == null)
        {
            GameObject_Showing = GameObject.FindWithTag("item_inspect");
        }
    }

    public void Object_Showing()
    {
        if (GameObject_Showing)
        {
            Destroy(GameObject_Showing);
        }
    }
  
}
