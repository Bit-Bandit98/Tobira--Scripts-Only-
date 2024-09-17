using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Yeah the naming in this file sucks. If you can do better, be my guest.
public class InteractableUI : MonoBehaviour
{
    [SerializeField] private PlayerInteract PlayerInteraction;
    [SerializeField] private GameObject InteractionIcon;
    [SerializeField] private bool Active = true;

    private void Update()
    {
        if (!Active)
        {
            SetInteractionIconActive(false);
            return;
        }

        if(PlayerInteraction.GetIsInteractable() != null && !DialogueController.instance.Dialoguing)
        {
            if (PlayerInteraction.GetIsInteractable().GetDisplayInteraction()) SetInteractionIconActive(true);
        }
        else
        {
            SetInteractionIconActive(false);
        }
    }


    public void SetInteractionIconActive(bool Active)
    {
        InteractionIcon.SetActive(Active);
    }

    public void SetActive(bool NewActive)
    {
        Active = NewActive;
        if(NewActive == false)
        {
            SetInteractionIconActive(false);
        }
    }
}
