using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool empty;

    public Transform slotIconGameObjects;

    private void Start()
    {
        slotIconGameObjects = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotIconGameObjects.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {
        if (!empty && item != null && item.GetComponent<Item>() != null)
        {
            item.GetComponent<Item>().ItemUsage();
        }
        else
        {
            Debug.Log("Slot vacío o ítem inválido, no se puede usar.");
        }

        item.GetComponent<Item>().ItemUsage();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }
}
