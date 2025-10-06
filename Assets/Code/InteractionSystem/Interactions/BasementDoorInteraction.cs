using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementDoorInteraction : DoorInteraction
{
    protected override void OpenDoor()
    {
        SceneManager.LoadScene("victoryScene");
    }


}