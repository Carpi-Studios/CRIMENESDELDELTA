using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    [SerializeField] protected GameObject inventory;
    private int allslots;
    private int enableSlots;
    private GameObject[] slots;
    [SerializeField] protected GameObject slotHolder;
    [SerializeField] float pickupRange = 2f;
    protected RectTransform inventoryPanel;

    void Start()
    {
        allslots = slotHolder.transform.childCount;
        slots = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            PickedUp();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

    }

    public void PickedUp()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, pickupRange);

        foreach (Collider col in hits)
        {
            if (col.CompareTag("Item"))
            {
                Item item = col.GetComponent<Item>();
                if (item != null)
                {
                    AddItem(col.gameObject, item.ID, item.type, item.description, item.icon);
                    col.gameObject.SetActive(false);
                    break;
                }
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }



    public void AddItem(GameObject itemObjects, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slots[i].GetComponent<Slot>().empty)
            {
                itemObjects.GetComponent<Item>().pickedUp = true;
                slots[i].GetComponent<Slot>().item = itemObjects;
                slots[i].GetComponent<Slot>().ID = itemID;
                slots[i].GetComponent<Slot>().type = itemType;
                slots[i].GetComponent<Slot>().description = itemDescription;
                slots[i].GetComponent<Slot>().icon = itemIcon;

                itemObjects.transform.parent = slots[i].transform;
                itemObjects.SetActive(true);

                slots[i].GetComponent<Slot>().UpdateSlot();

                slots[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }

    public bool HasItemID(int itemID)
    {
        for (int i = 0; i < allslots; i++)
            if (!slots[i].GetComponent<Slot>().empty && slots[i].GetComponent<Slot>().ID == itemID) return true;

        return false;
    }
}

