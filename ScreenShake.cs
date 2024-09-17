using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float XIntensity = 1f, YIntensity = 1f, Frequency;
    [SerializeField] private CircleCollider2D CircleCollider;
    [SerializeField] private AnimationCurve StrengthCurve;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null) return;
        PlayerCamera.transform.localPosition = GetPerlinRandomCoordinantsWithStrength();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCamera.transform.localPosition = Vector3.zero;
    }

    private float GetStrengthRelativeToDistance()
    {
        float Dist = Vector3.Distance(PlayerController.instance.transform.position, CircleCollider.transform.position);
        
        return StrengthCurve.Evaluate(1 - Dist / CircleCollider.radius);
    }

    private Vector3 GetPerlinRandomCoordinantsWithStrength()
    {
        float Timer = Time.time * Frequency;
        float XCoordinate = Mathf.PerlinNoise(Timer * XIntensity -20f, 0f) * 2 - 1;
        float YCoordinate = Mathf.PerlinNoise(Timer * YIntensity + 20f, 0f) * 2 - 1;
        return new Vector3(XCoordinate, YCoordinate, 0f) * GetStrengthRelativeToDistance();
    }
}
