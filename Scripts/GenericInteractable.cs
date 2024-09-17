using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GenericInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent InteractionEvents;
    [SerializeField] private bool DisplayInteractionUI = true;
    public bool GetDisplayInteraction()
    {
        return DisplayInteractionUI;
    }

    public void Interact()
    {
        if(InteractionEvents != null)
        {
            InteractionEvents.Invoke();
        }
    }
}
