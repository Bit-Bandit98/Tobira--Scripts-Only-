using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDirectionMediator : MonoBehaviour
{

    [SerializeField] private PlayerController Player;
    [SerializeField] private AnimationDirection AnimateDirection;


    private void Update()
    {
        AnimateDirection.SetIsMoving(Player.GetRBVelocity());
        AnimateDirection.SetFacingDirection(Player.GetPlayerDirection());
    }


}
