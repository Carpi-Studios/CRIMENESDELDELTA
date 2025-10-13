using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public Transform player;
    public GameObject interactionCanvas;
    public float activationDistance = 3f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        bool isNear = distance <= activationDistance;

        if (interactionCanvas.activeSelf != isNear)
        {
            interactionCanvas.SetActive(isNear);
        }
    }

}
