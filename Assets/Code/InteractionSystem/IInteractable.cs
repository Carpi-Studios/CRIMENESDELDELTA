using UnityEngine;

/// <summary>
/// An interface for Interacting with objects,
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// This method checks if the Interactable has enabled it interaction enabled
    /// </summary>
    /// <returns> true if it's enabled, false if it's not enabled. </returns>
    public bool CanInteract();


    /// <summary>
    /// This method triggers the Interactable action, when an <paramref name="interactor"/> activates it
    /// 
    /// </summary>
    /// <param name="interactor"> The Interactor witch interacted with the Interactable <see cref="Interactor"/>></param>
    /// <returns> true if triggered correctly, false if it's not triggered. </returns>
    public bool Interact(IInteract interactor);
}