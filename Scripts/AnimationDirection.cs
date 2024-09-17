using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class determines what direction the player is facing based on their movement vector.
public class AnimationDirection : MonoBehaviour
{
    [SerializeField] private Animator AnimatorInstance;
    private string CurrentDirection;
    private bool IsMoving = false;
    [Header("Directions")]
    [SerializeField] private string North = "North";
    [SerializeField] private string East = "East";
    [SerializeField] private string South = "South";
    [SerializeField] private string West = "West";
    [SerializeField] private string NorthWest = "NorthWest";
    [SerializeField] private string NorthEast = "NorthEast";
    [SerializeField] private string SouthWest = "SouthWest";
    [SerializeField] private string SouthEast = "SouthEast";

    Dictionary<Vector2, string> DirectionDictionary;
    private void Awake()
    {
        DirectionDictionary = new Dictionary<Vector2, string> {

            { new Vector2(1, 0), East},
            { new Vector2(-1, 0), West},
            { new Vector2(0, 1), North},
            { new Vector2(0, -1), South},
            { new Vector2(1, 1), NorthEast},
            { new Vector2(-1, 1), NorthWest},
            { new Vector2(-1, -1), SouthWest},
            { new Vector2(1, -1), SouthEast}
        };
    }

    private void Start()
    {
        AnimatorInstance.speed = 0f;
    }

    private void SetCurrentDirection(string DirectionString)
    {
        if (IsMoving) AnimatorInstance.speed = 1f;
        else AnimatorInstance.speed = 0f;

        if (DirectionString == CurrentDirection) return;
        CurrentDirection = DirectionString;
        AnimatorInstance.Play(CurrentDirection);

    }


    public void SetFacingDirection(Vector2 FacingDirection)
    {
        if (DirectionDictionary.ContainsKey(FacingDirection)) { 
        SetCurrentDirection(DirectionDictionary[FacingDirection]);
        }
    }

    public void SetIsMoving(Vector2 Velocity)
    {
        IsMoving = Velocity.magnitude > 0f;
    }

    
}
