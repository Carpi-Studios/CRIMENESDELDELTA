using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;


public class BasementDoor : MonoBehaviour

{

    private bool isActive;
    public void DoorActive()
    {
        isActive = true;
        Debug.Log("Se ha abierto el sotano!");
    }
    public void DoorInactive()
    {
        isActive = false;
        Debug.Log("No puede entrar al sotano");
    }
    public bool IsActive() => isActive;

}
