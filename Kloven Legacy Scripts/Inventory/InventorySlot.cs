using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Transform canvas;
    public GameObject gameobject;
    public Transform Display_Position;
    public Button button;
    public Image icon;
    public Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }


    public void InspectItem()
    {
        if(item != null)
        {
            item.Inspect();
            
            if (gameobject == null)
            {
               
                gameobject = Instantiate(item.gameObject);
                Debug.Log("create");
            }
            else
            {
                Destroy(gameobject.gameObject);
                //gameobject = null;
                Debug.Log("delete");
            }
            gameobject.transform.parent = canvas.parent;
            gameobject.transform.position = Display_Position.transform.position;
            gameobject.transform.localScale = Display_Position.transform.localScale;
        }
    }
}
