using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector] public bool pickedUp;

    [HideInInspector] public bool equiped;
    [HideInInspector] public GameObject weaponManager;
    [HideInInspector] public GameObject weapon;
    [HideInInspector] public GameObject sotano;
    public bool playersWeapon;

    private void Start()
    {
        weaponManager = GameObject.FindWithTag("weaponManager");
        if (!playersWeapon)
        {
            int allweapons = weaponManager.transform.childCount;
            for (int i = 0; i < allweapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    private void Update()
    {
        if (equiped)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                equiped = false;
            }
            if (equiped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void ItemUsage()
    {
        switch (type)
        {
            case "weapon":
                if (weaponManager == null)
                    weaponManager = GameObject.FindWithTag("weaponManager");

                if (weapon == null)
                {
                    int allweapons = weaponManager.transform.childCount;
                    for (int i = 0; i < allweapons; i++)
                    {
                        Item candidate = weaponManager.transform.GetChild(i).GetComponent<Item>();
                        if (candidate != null && candidate.ID == ID)
                        {
                            weapon = candidate.gameObject;
                            break;
                        }
                    }
                }

                if (weapon != null)
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<Item>().equiped = true;
                }
                break;

            case "pista":
               
                clueActive clueDisplay = GameObject.FindWithTag("ClueDisplay").GetComponent<clueActive>();
                if (clueDisplay != null)
                {
                    clueDisplay.ShowClue();
                }
                

                    break;
            case "llave":
                              
                    ActiveDoor();
                

                break;

            default:
                
                break;
        }
        Debug.Log("Tipo de ítem no reconocido: " + type);
    }
    private void ActiveDoor()
    {
      if (type=="llave")
        {
            basementDoor basementDoor = GameObject.FindWithTag("Basementdoor").GetComponent< basementDoor>();
            if(basementDoor != null)
            {
                basementDoor.DoorActive();
            }
            else
            {
                basementDoor.DoorInactive();
            }
          
        }
    }


}

