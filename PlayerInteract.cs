using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private float InteractionLength = 1f;
    [SerializeField] private LayerMask IgnoreLayer;
    [SerializeField] private KeyCode[] InteractionKey;

    private GameObject CachedHitOBJ;

    public void PlayerInteraction(Vector3 BeamDirection)
    {
        ShootInteractionBeam(BeamDirection);
        InteractWithOBJ();
    }

    RaycastHit2D HitOBJ;
    private void ShootInteractionBeam(Vector3 BeamDirection)
    {
        Debug.DrawRay(gameObject.transform.position, ((gameObject.transform.position + BeamDirection) - gameObject.transform.position) * InteractionLength, Color.red);

        HitOBJ = Physics2D.Raycast(gameObject.transform.position, BeamDirection, InteractionLength, ~IgnoreLayer);
        
        if(HitOBJ.collider != null)
        {
            SetCachedHitOBJ(HitOBJ.collider.gameObject);
                  //  Debug.Log("Hit!");
        }else{
            SetCachedHitOBJ(null);
        }
    }


    
    private void InteractWithOBJ()
    {
        if (!IsCached()) return;
        foreach (KeyCode kc in InteractionKey)
        {
            if (Input.GetKeyDown(kc))
            {
                IInteractable CachedInteractable = GetCachedHitOBJ().GetComponent<IInteractable>();
                if (CachedInteractable == null) return;
                CachedInteractable.Interact();
                break;
            }
        }
        
    }


    public GameObject GetCachedHitOBJ()
    {
        return CachedHitOBJ;
    }

    public void SetCachedHitOBJ(GameObject NewHitOBJ)
    {
        if (NewHitOBJ == CachedHitOBJ) return;
        CachedHitOBJ = NewHitOBJ;
    }

    public bool IsCached()
    {
        return GetCachedHitOBJ() != null;
    }

    public IInteractable GetIsInteractable()
    {
        if (GetCachedHitOBJ() == null) return null;
        else return GetCachedHitOBJ().GetComponent<IInteractable>();
    }
}
