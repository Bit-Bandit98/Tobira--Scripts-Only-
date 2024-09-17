using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private bool DisplayInteractionUI = true;
    public bool GetDisplayInteraction()
    {
        return DisplayInteractionUI;
    }

    public void Interact()
    {
        Debug.Log("INTERACTED!");
    }
}
