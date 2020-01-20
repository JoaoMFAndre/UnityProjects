using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    private Inventory inventory;
    public InventorySlot[] slots;


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    void UpdateUI()
    {
        for(int i = 0; i< slots.Length; i++)
        {
            if( i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
        }
    }
}
